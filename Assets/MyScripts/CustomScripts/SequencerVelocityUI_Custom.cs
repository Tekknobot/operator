using UnityEngine;
using System.Collections.Generic;

namespace AudioHelm
{
    public class SequencerVelocityUI_Custom
    {
        const float velocityMeterWidth = 3.0f;
        const float velocityHandleWidth = 7.0f;
        const float velocityHandleGrabWidth = 13.0f;

        Note currentNote;
        float currentNoteSerialized = 0;

        float leftPadding = 0.0f;
        float rightPadding = 0.0f;
        Color activeAreaColor = new Color(0.6f, 0.6f, 0.6f);
        Color background = new Color(0.5f, 0.5f, 0.5f);
        Color velocityColor = new Color(1.0f, 0.3f, 0.3f);
        Color velocityActiveColor = new Color(0.6f, 1.0f, 1.0f);

        float sixteenthWidth = 1.0f;
        float height = 1.0f;
        float startTime = 0.0f;
        float endTime = 1.0f;

        private GUIStyle activeAreaColorStyle = null;
        private void InitActiveColorStyle() {
            if(activeAreaColorStyle == null ) {
                activeAreaColorStyle = new GUIStyle( GUI.skin.box );
                activeAreaColorStyle.normal.background = MakeTex( 2, 2, activeAreaColor);
            }
        } 

        private GUIStyle backgroundColorStyle = null;
        private void InitBackgroundColorStyle() {
            if(backgroundColorStyle == null ) {
                backgroundColorStyle = new GUIStyle( GUI.skin.box );
                backgroundColorStyle.normal.background = MakeTex( 2, 2, Color.blue);
            }
        }    

        private GUIStyle blackColorStyle = null;
        private void InitBlackColorStyle() {
            if(blackColorStyle == null ) {
                blackColorStyle = new GUIStyle( GUI.skin.box );
                blackColorStyle.normal.background = MakeTex( 2, 2, Color.black);
            }
        }             

        private Texture2D MakeTex( int width, int height, Color col )
        {
            Color[] pix = new Color[width * height];
            for( int i = 0; i < pix.Length; ++i )
            {
                pix[ i ] = col;
            }
            Texture2D result = new Texture2D( width, height );
            result.SetPixels( pix );
            result.Apply();
            return result;
        }                

        public SequencerVelocityUI_Custom(float left, float right)
        {
            leftPadding = left;
            rightPadding = right;
        }

        public bool MouseActive()
        {
            return currentNote != null;
        }

        void MouseUp()
        {
            currentNote = null;
            currentNoteSerialized = 0;
        }

        void MouseDown(Rect rect, Sequencer sequencer, Vector2 mousePosition, int allNotes)
        {
            currentNote = null;
            float closest = 2.0f  * velocityHandleGrabWidth;
            float mouseX = mousePosition.x - rect.x - leftPadding;
            float mouseY = mousePosition.y - rect.y;

            List<Note> noteOns = sequencer.GetAllNoteOnsInRange(startTime, endTime);
            foreach (Note note in noteOns)
            {               
                float x = sixteenthWidth * (note.start - startTime);
                float yInv = note.velocity * (rect.height - velocityHandleWidth) + velocityHandleWidth / 2.0f;
                float y = rect.height - yInv;
                float xDiff = Mathf.Abs(x - mouseX);
                float yDiff = Mathf.Abs(y - mouseY);
                float diffTotal = xDiff + yDiff;

                if (xDiff <= velocityHandleGrabWidth && yDiff <= velocityHandleGrabWidth && diffTotal < closest)
                {
                    closest = diffTotal;
                    currentNote = note;

                    // int serializedNoteRow = allNotes.GetArrayElementAtIndex(currentNote.note);
                    // int serializedNoteList = serializedNoteRow.FindPropertyRelative("notes");
                    // List<Note> noteList = sequencer.allNotes[currentNote.note].notes;
                    // int index = noteList.IndexOf(currentNote);
                    // if (index >= 0)
                    //     currentNoteSerialized = serializedNoteList.GetArrayElementAtIndex(index);
                }
            }

            if (currentNote != null) {
                //Undo.RegisterCompleteObjectUndo(sequencer, "Set Note Velocity");
            }
        }

        void MouseDrag(float velocity, int allNotes)
        {
            if (currentNote == null)
                return;

            currentNote.velocity = velocity;
            currentNoteSerialized = velocity;
        }

        public bool DoVelocityEvents(Rect rect, Sequencer sequencer, int allNotes)
        {
            Event evt = Event.current;

            float velocityMovementHeight = rect.height - velocityHandleWidth;
            float minVelocityY = rect.y + velocityHandleWidth;
            float velocity = 1.0f - (evt.mousePosition.y - minVelocityY) / velocityMovementHeight;
            velocity = Mathf.Clamp(velocity, 0.001f, 1.0f);

            if (evt.type == EventType.MouseUp && MouseActive())
            {
                MouseUp();
                return true;
            }

            if (evt.type == EventType.MouseDown)
            {
                MouseDown(rect, sequencer, evt.mousePosition, allNotes);
                MouseDrag(velocity, allNotes);
            }
            else if (evt.type == EventType.MouseDrag && MouseActive())
                MouseDrag(velocity, allNotes);
            return true;
        }

        void DrawNote(float x, float velocity, Color color)
        {
            float h = velocity * (height - velocityHandleWidth) + velocityHandleWidth / 2.0f;
            float y = height - h;

            GUI.Box(new Rect(x - velocityMeterWidth / 2.0f, y, velocityMeterWidth, h), string.Empty);
            GUI.Box(new Rect(x - velocityHandleWidth / 2.0f, y - velocityHandleWidth / 2.0f, velocityHandleWidth, velocityHandleWidth), string.Empty);
        }

        void DrawNoteVelocities(Sequencer sequencer, float start, float end, float width)
        {
            if (sequencer.allNotes == null)
                return;

            List<Note> notes = sequencer.GetAllNoteOnsInRange(start, end);
            foreach (Note note in notes)
            {
                float percent = (note.start - start) / (end - start);
                DrawNote(percent * width, note.velocity, velocityColor);
            }
        }

        public void DrawTextMeasurements(Rect rect)
        {
            const int barWidth = 1;

            GUIStyle style = new GUIStyle();
            style.fontSize = 12;
            style.padding = new RectOffset(0, barWidth, 0, 0);
            style.alignment = TextAnchor.UpperRight;
            GUI.Label(rect, "127", style);
            style.alignment = TextAnchor.LowerRight;
            GUI.Label(rect, "1", style);

            Rect bar = new Rect(rect.x + rect.width - 1, rect.y, 1, rect.height);
            Rect top = new Rect(rect.x + rect.width - barWidth, rect.y, barWidth, 1);
            Rect bottom = new Rect(rect.x + rect.width - barWidth, rect.y + rect.height - 1, barWidth, 1);
            Rect middle = new Rect(rect.x + rect.width - barWidth / 2.0f, rect.y + rect.height / 2.0f, barWidth / 2.0f, 1);
            InitBlackColorStyle();
            GUI.Box(bar, string.Empty, blackColorStyle);
            GUI.Box(top, string.Empty, blackColorStyle);
            GUI.Box(bottom, string.Empty, blackColorStyle);
            GUI.Box(middle, string.Empty, blackColorStyle);
        }

        public void DrawSequencerVelocities(Rect rect, Sequencer sequencer, float start, float end)
        {
            Rect activeArea = new Rect(rect);
            activeArea.x += leftPadding;
            activeArea.width -= leftPadding + rightPadding;

            startTime = start;
            endTime = end;
            sixteenthWidth = activeArea.width / (end - start);
            height = activeArea.height;

            InitBackgroundColorStyle();
            GUI.Box(rect, string.Empty, backgroundColorStyle);
            InitActiveColorStyle();
            GUI.Box(activeArea, string.Empty, activeAreaColorStyle);

            Rect leftBufferArea = new Rect(rect);
            leftBufferArea.width = leftPadding;
            DrawTextMeasurements(leftBufferArea);

            GUI.BeginGroup(activeArea);
            DrawNoteVelocities(sequencer, start, end, activeArea.width);
            if (currentNote != null)
            {
                float percent = (currentNote.start - start) / (end - start);
                DrawNote(percent * activeArea.width, currentNote.velocity, velocityActiveColor);
            }

            GUI.EndGroup();
        }
    }
}
//#endif