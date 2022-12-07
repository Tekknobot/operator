using UnityEngine;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace AudioHelm
{
    public class SequencerUI_Custom
    {
        enum Mode
        {
            kWaiting,
            kAdding,
            kDeleting,
            kKeyboarding,
            kChangingVelocity,
            kDraggingStart,
            kDraggingEnd,
            kNumModes
        }

        SequencerVelocityUI_Custom velocities = null;
        const int velocitySectionHeight = 50;

        public SequencerUI_Custom(float keyboard, float scroll)
        {
            keyboardWidth = keyboard;
            rightPadding = scroll;
            bottomPadding = scroll;
            velocities = new SequencerVelocityUI_Custom(keyboardWidth, rightPadding);
        }

        public int minKey = 0;
        public int maxKey = Utils.kMidiSize - 1;

        const float grabResizeWidth = 4.0f;
        const float minNoteTime = 0.15f;
        const float defaultVelocity = 0.8f;
        const float dragDeltaStartRounding = 0.8f;

        float keyboardWidth = 100.0f;
        float rightPadding = 15.0f;
        float bottomPadding = 15.0f;

        Mode mode = Mode.kWaiting;
        Note activeNote = null;
        bool mouseActive = false;
        bool roundingToIndex = false;

        int pressNote = 0;
        float pressTime = 0.0f;
        float activeTime = 0.0f;
        float dragTime = 0.0f;
        int pressedKey = -1;

        Color emptyCellBlack = new Color(0.5f, 0.5f, 0.5f);
        Color emptyCellWhite = new Color(0.6f, 0.6f, 0.6f);
        Color noteDivision = new Color(0.4f, 0.4f, 0.4f);
        Color beatDivision = new Color(0.2f, 0.2f, 0.2f);
        Color fullCellFullVelocity = Color.red;
        Color fullCellZeroVelocity = new Color(1.0f, 0.8f, 0.8f);
        Color pressedCell = new Color(0.6f, 1.0f, 1.0f);
        Color deletingCell = new Color(0.7f, 1.0f, 0.7f);
        Color lightenColor = new Color(1.0f, 1.0f, 1.0f, 0.1f);
        Color darkenColor = new Color(0.0f, 0.0f, 0.0f, 0.05f);
        Color blackKey = Color.black;
        Color whiteKey = Color.white;
        Color blackKeyPressed = Color.red;
        Color whiteKeyPressed = Color.red;

        float rowHeight = 10.0f;
        const float minRowHeight = 10.0f;
        const float maxRowHeight = 35.0f;
        int numRows = Utils.kMidiSize;
        int numCols = 16;
        int numSixteenths = 16;
        int notesPerBeat = 4;
        const float minColWidth = 8.0f;
        const float maxColZoomWidth = 60.0f;
        float colWidth = 30.0f;
        float sixteenthWidth = 30.0f;

        private GUIStyle keyColorStyle = null;
        private void InitKeyColorStyle() {
            if(keyColorStyle == null ) {
                keyColorStyle = new GUIStyle( GUI.skin.box );
                keyColorStyle.normal.background = MakeTex( 2, 2, Color.white);
            }
        }        

        private GUIStyle rowColorStyle = null;
        private void InitRowColorStyle() {
            if(rowColorStyle == null ) {
                rowColorStyle = new GUIStyle( GUI.skin.box );
                rowColorStyle.normal.background = MakeTex( 2, 2, emptyCellBlack);
            }
        }       

        private GUIStyle darkenColorStyle = null;
        private void InitDarkenColorStyle() {
            if(darkenColorStyle == null ) {
                darkenColorStyle = new GUIStyle( GUI.skin.box );
                darkenColorStyle.normal.background = MakeTex( 2, 2, darkenColor);
            }
        }                       

        private GUIStyle whiteColorStyle = null;
        private void InitWhiteColorStyle() {
            if(whiteColorStyle == null ) {
                whiteColorStyle = new GUIStyle( GUI.skin.box );
                whiteColorStyle.normal.background = MakeTex( 2, 2, Color.white);
            }
        }

        private GUIStyle blackColorStyle = null;
        private void InitBlackColorStyle() {
            if(blackColorStyle == null ) {
                blackColorStyle = new GUIStyle( GUI.skin.box );
                blackColorStyle.normal.background = MakeTex( 2, 2, Color.black);
            }
        }        

        private GUIStyle lightenColorStyle = null;
        private void InitLightenColorStyle() {
            if(lightenColorStyle == null ) {
                lightenColorStyle = new GUIStyle( GUI.skin.box );
                lightenColorStyle.normal.background = MakeTex( 2, 2, lightenColor);
            }
        }

        private GUIStyle beatDivisionStyle = null;
        private void InitBeatDivisionStyle() {
            if(beatDivisionStyle == null ) {
                beatDivisionStyle = new GUIStyle( GUI.skin.box );
                beatDivisionStyle.normal.background = MakeTex( 2, 2, beatDivision);
            }
        }
        
        private GUIStyle noteDivisionStyle = null;
        private void InitNoteDivisionStyle() {
            if(noteDivisionStyle == null ) {
                noteDivisionStyle = new GUIStyle( GUI.skin.box );
                noteDivisionStyle.normal.background = MakeTex( 2, 2, noteDivision);
            }
        }

        private GUIStyle noteOutsideRectStyle = null;
        private void InitNoteOutsideRectStyle() {
            if(noteOutsideRectStyle == null ) {
                noteOutsideRectStyle = new GUIStyle( GUI.skin.box );
                noteOutsideRectStyle.normal.background = MakeTex( 2, 2, Color.black );
            }
        }
        
        private GUIStyle noteRectStyle = null;
        private void InitNoteRectStyle() {
            if(noteRectStyle == null ) {
                noteRectStyle = new GUIStyle( GUI.skin.box );
                noteRectStyle.normal.background = MakeTex( 2, 2, Color.red );
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

        Vector2 scrollPosition;

        Vector2 GetSequencerPosition(Rect rect, Vector2 mousePosition, float sequencerLength)
        {
            if (!rect.Contains(mousePosition))
                return -Vector2.one;

            Vector2 localPosition = mousePosition - rect.position + scrollPosition;
            float note = minKey + numRows - Mathf.Floor((localPosition.y / rowHeight)) - 1;
            float time = sequencerLength * (localPosition.x - keyboardWidth) / (numCols * colWidth);
            return new Vector2(time, note);
        }

        public bool MouseActive()
        {
            return mouseActive;
        }

        void MouseDown(int note, float time, Sequencer sequencer, int allNotes)
        {
            float divisionLength = sequencer.GetDivisionLength();
            roundingToIndex = false;
            mouseActive = true;
            activeNote = sequencer.GetNoteInRange(note, time, time);
            dragTime = time;
            activeTime = time;
            pressTime = time;
            pressNote = note;

            if (pressedKey >= 0)
            {
                sequencer.NoteOff(pressedKey);
                pressedKey = -1;
            }

            if (time < 0.0f)
            {
                mode = Mode.kKeyboarding;
                pressedKey = note;
                sequencer.NoteOn(pressedKey, 1.0f);
                return;
            }
            else if (activeNote != null)
            {
                float startPixels = colWidth * (time - activeNote.start) / divisionLength;
                float endPixels = colWidth * (activeNote.end - time) / divisionLength;

                if (endPixels <= grabResizeWidth)
                    mode = Mode.kDraggingEnd;
                else if (startPixels <= grabResizeWidth)
                    mode = Mode.kDraggingStart;
                else
                    mode = Mode.kDeleting;
            }
            else
                mode = Mode.kAdding;
        }

        bool MouseDrag(int note, float time, Sequencer sequencer, int allNotes)
        {
            float divisionLength = sequencer.GetDivisionLength();
            float clampedTime = Mathf.Clamp(time, 0.0f, sequencer.length);
            float lastDragTime = dragTime;
            dragTime = clampedTime;

            float newActiveTime = dragTime;
            if (roundingToIndex)
                newActiveTime = divisionLength * Mathf.Round(dragTime / divisionLength);

            if (Mathf.Abs(dragTime - pressTime) >= dragDeltaStartRounding)
                roundingToIndex = true;

            if (mode == Mode.kKeyboarding)
            {
                if (note == pressedKey)
                    return false;

                sequencer.NoteOff(pressedKey);
                sequencer.NoteOn(note);
                pressedKey = note;
                return true;
            }
            else if (mode == Mode.kDraggingStart)
            {
                if (activeNote == null)
                    return false;

                newActiveTime = Mathf.Min(activeNote.end - minNoteTime, newActiveTime);
                bool redraw = activeTime == newActiveTime;
                activeTime = newActiveTime;
                return redraw;
            }
            else if (mode == Mode.kDraggingEnd)
            {
                if (activeNote == null)
                    return false;

                newActiveTime = Mathf.Max(activeNote.start + minNoteTime, newActiveTime);
                bool redraw = activeTime == newActiveTime;
                activeTime = newActiveTime;
                return redraw;
            }
            else if (mode == Mode.kAdding)
            {
                int lastIndex = Mathf.FloorToInt(lastDragTime / divisionLength);
                int index = Mathf.FloorToInt(time / divisionLength);

                return lastIndex != index;
            }
            return true;
        }

        void CopyNoteToSerializedProperty(Note note, float serializedNote)
        {
            serializedNote = note.note;
            serializedNote = note.velocity;
            serializedNote = note.start;
            serializedNote = note.end;
            //serializedNote.FindPropertyRelative("parent").objectReferenceValue = note.parent;
        }

        // void CopyNoteRowToSerializedProperty(NoteRow row, SerializedProperty serializedRow)
        // {
        //     SerializedProperty noteList = serializedRow.FindPropertyRelative("notes");
        //     noteList.arraySize = row.notes.Count;

        //     for (int i = 0; i < row.notes.Count; ++i)
        //     {
        //         Note note = row.notes[i];
        //         SerializedProperty serializedNote = noteList.GetArrayElementAtIndex(i);
        //         CopyNoteToSerializedProperty(note, serializedNote);
        //     }
        // }

        void MouseUp(float time, Sequencer sequencer, int allNotes)
        {
            float divisionLength = sequencer.GetDivisionLength();
            mouseActive = false;
            if (mode == Mode.kKeyboarding)
            {
                sequencer.NoteOff(pressedKey);
                pressedKey = -1;
                return;
            }

            dragTime = Mathf.Clamp(time, 0.0f, sequencer.length);
            float startTime = Mathf.Min(pressTime, dragTime);
            float endTime = Mathf.Max(pressTime, dragTime);

            if (mode == Mode.kDraggingStart)
            {
                //Undo.RecordObject(sequencer, "Move Note Start");

                if (activeNote != null)
                {
                    float newStart = Mathf.Min(activeNote.end - minNoteTime, activeTime);
                    sequencer.ClampNotesInRange(pressNote, newStart, activeNote.end, activeNote);

                    activeNote.start = newStart;
                }
            }
            else if (mode == Mode.kDraggingEnd)
            {
                //Undo.RecordObject(sequencer, "Move Note End");

                if (activeNote != null)
                {
                    float newEnd = Mathf.Max(activeNote.start + minNoteTime, activeTime);
                    sequencer.ClampNotesInRange(pressNote, activeNote.start, newEnd, activeNote);

                    activeNote.end = newEnd;
                }
            }
            else if (mode == Mode.kAdding)
            {
                //Undo.RecordObject(sequencer, "Add Sequencer Notes");
                int startDragIndex = Mathf.FloorToInt(startTime / divisionLength);
                int endDragIndex = Mathf.CeilToInt(endTime / divisionLength);

                sequencer.ClampNotesInRange(pressNote, startDragIndex * divisionLength,
                                            endDragIndex * divisionLength);
                for (int i = startDragIndex; i < endDragIndex; ++i)
                    sequencer.AddNote(pressNote, i * divisionLength, (i + 1) * divisionLength, defaultVelocity);
            }
            else if (mode == Mode.kDeleting)
            {
                //Undo.RecordObject(sequencer, "Delete Sequencer Notes");
                sequencer.RemoveNotesInRange(pressNote, startTime, endTime);
            }
            mode = Mode.kWaiting;

            if (!Application.isPlaying)
            {
                //CopyNoteRowToSerializedProperty(sequencer.allNotes[pressNote], allNotes.GetArrayElementAtIndex(pressNote));
            }
        }

        public bool DoSequencerEvents(Rect rect, Sequencer sequencer, int allNotes)
        {
            Event evt = Event.current;
            if (!evt.isMouse)
                return false;

            Vector2 sequencerPosition = GetSequencerPosition(rect, evt.mousePosition, sequencer.length);
            float time = sequencerPosition.x;

            if (evt.type == EventType.MouseUp && mouseActive)
            {
                if (mode == Mode.kChangingVelocity)
                {
                    velocities.DoVelocityEvents(GetVelocityRectGlobal(rect), sequencer, allNotes);
                    mouseActive = false;
                }
                else
                    MouseUp(time, sequencer, allNotes);
                return true;
            }

            int note = (int)sequencerPosition.y;
            Rect ignoreScrollRect = new Rect(rect);
            ignoreScrollRect.width -= rightPadding;
            ignoreScrollRect.height -= bottomPadding;
            if (evt.type == EventType.MouseDown && ignoreScrollRect.Contains(evt.mousePosition))
            {
                ignoreScrollRect.height -= velocitySectionHeight;
                if (ignoreScrollRect.Contains(evt.mousePosition))
                {
                    if (note > maxKey || note < minKey)
                        return false;

                    MouseDown(note, time, sequencer, allNotes);
                }
                else
                {
                    mode = Mode.kChangingVelocity;
                    mouseActive = true;
                    velocities.DoVelocityEvents(GetVelocityRectGlobal(rect), sequencer, allNotes);
                }
            }
            else if (evt.type == EventType.MouseDrag && mouseActive)
            {
                if (mode == Mode.kChangingVelocity)
                    return velocities.DoVelocityEvents(GetVelocityRectGlobal(rect), sequencer, allNotes);
                return MouseDrag(note, time, sequencer, allNotes);
            }
            return true;
        }

        void DrawNoteRows(Rect drawableArea)
        {
            GUIStyle cStyle = new GUIStyle();
            cStyle.fontSize = 16;
            cStyle.alignment = TextAnchor.MiddleRight;
            cStyle.padding = new RectOffset(0, 1, 0, 0);

            int lastKey = GetMaxVisibleKey();
            int firstKey = GetMinVisibleKey(drawableArea.height);
            float y = (maxKey - lastKey) * rowHeight;            
            for (int i = lastKey; i >= firstKey; --i)
            {
                InitKeyColorStyle();
                Color keyColor = whiteKey;
                Color rowColor = emptyCellWhite;

                if (Utils.IsBlackKey(i))
                {
                    if (pressedKey == i) {
                        keyColorStyle = new GUIStyle( GUI.skin.box );
                        keyColorStyle.normal.background = MakeTex( 2, 2, Color.red);                        
                        keyColor = blackKeyPressed;
                        Rect key3 = new Rect(scrollPosition.x, y, keyboardWidth, rowHeight - 1);
                        Rect row3 = new Rect(scrollPosition.x + keyboardWidth, y, drawableArea.width - keyboardWidth, rowHeight);
                        GUI.Box(key3, string.Empty, keyColorStyle);                        
                    }
                    else {
                        keyColorStyle = new GUIStyle( GUI.skin.box );
                        keyColorStyle.normal.background = MakeTex( 2, 2, Color.black);                        
                        keyColor = blackKey;
                    }
                    rowColor = emptyCellBlack;
                    Rect key2 = new Rect(scrollPosition.x, y, keyboardWidth, rowHeight - 1);
                    Rect row2 = new Rect(scrollPosition.x + keyboardWidth, y, drawableArea.width - keyboardWidth, rowHeight);
                    GUI.Box(key2, string.Empty, keyColorStyle);                     
                }
                else if (pressedKey == i) {
                    keyColorStyle = new GUIStyle( GUI.skin.box );
                    keyColorStyle.normal.background = MakeTex( 2, 2, Color.red);                      
                    keyColor = whiteKeyPressed;
                    Rect key1 = new Rect(scrollPosition.x, y, keyboardWidth, rowHeight - 1);
                    Rect row1 = new Rect(scrollPosition.x + keyboardWidth, y, drawableArea.width - keyboardWidth, rowHeight);
                    GUI.Box(key1, string.Empty, keyColorStyle);                     
                }

                Rect key = new Rect(scrollPosition.x, y, keyboardWidth, rowHeight - 1);
                Rect row = new Rect(scrollPosition.x + keyboardWidth, y, drawableArea.width - keyboardWidth, rowHeight);
                //GUI.Box(key, string.Empty, keyColorStyle);
                //EditorGUI.DrawRect(new Rect(key.x, key.yMax, key.width, 1), Color.black);
                if (i % Utils.kNotesPerOctave == 0)
                    GUI.Label(key, "C" + Utils.GetOctave(i), cStyle);

                InitRowColorStyle();
                GUI.Box(row, string.Empty, rowColorStyle);
                InitDarkenColorStyle();
                GUI.Box(new Rect(row.x, row.yMax - 1, row.width, 1), string.Empty, darkenColorStyle);
                y += rowHeight;
            }
        }

        void DrawBarHighlights(Rect drawableArea)
        {
            float barWidth = colWidth * notesPerBeat;

            int startBar = Mathf.FloorToInt(scrollPosition.x / barWidth);
            int endBar = Mathf.FloorToInt((scrollPosition.x + drawableArea.width) / barWidth);
            float x = keyboardWidth + startBar * barWidth;
            for (int i = startBar; i <= endBar; ++i)
            {
                if (i % 2 != 0)
                {
                    float startX = Mathf.Max(scrollPosition.x + keyboardWidth, x);
                    float width = x + barWidth - startX;
                    Rect bar = new Rect(startX, scrollPosition.y, width, drawableArea.height);
                    InitLightenColorStyle();
                    GUI.Box(bar, string.Empty, lightenColorStyle);
                }
                x += barWidth;
            }
        }

        void DrawNoteDivisionLines(Rect drawableArea)
        {
            int startCol = Mathf.CeilToInt(GetMinVisibleColumn());
            int endCol = Mathf.FloorToInt(GetMaxVisibleColumn(drawableArea.width));
            float x = keyboardWidth + startCol * colWidth;
            for (int i = startCol; i <= endCol; ++i)
            {
                Rect line = new Rect(x, scrollPosition.y, 1.0f, drawableArea.height);
                if (i % notesPerBeat == 0) {
                    InitBeatDivisionStyle();
                    GUI.Box(line, string.Empty, beatDivisionStyle);
                    //EditorGUI.DrawRect(line, beatDivision);
                }
                else {
                    InitNoteDivisionStyle();
                    GUI.Box(line, string.Empty, noteDivisionStyle);
                    //EditorGUI.DrawRect(line, noteDivision);
                }
                x += colWidth;
            }
        }

        void DrawNote(int note, float startColumn, float endColumn, Color color)
        {
            float x = startColumn * colWidth + keyboardWidth;
            float y = (numRows - (note - minKey) - 1) * rowHeight;
            float width = endColumn * colWidth + keyboardWidth - x;
            Rect noteOutsideRect = new Rect(x, y, width + 1, rowHeight);
            Rect noteRect = new Rect(x + 1, y + 1, width - 1, rowHeight - 2);
            InitNoteOutsideRectStyle();
            GUI.Box(noteOutsideRect, string.Empty, noteOutsideRectStyle);
            InitNoteRectStyle();
            GUI.Box(noteRect, string.Empty, noteRectStyle);
            Rect leftResizeRect = new Rect(x, y, grabResizeWidth, rowHeight);
            Rect rightResizeRect = new Rect(noteRect.xMax - grabResizeWidth, y, grabResizeWidth, rowHeight);
            //EditorGUIUtility.AddCursorRect(leftResizeRect, MouseCursor.SplitResizeLeftRight);
            //EditorGUIUtility.AddCursorRect(rightResizeRect, MouseCursor.SplitResizeLeftRight);
        }

        void DrawRowNotes(List<Note> notes, float divisionLength, Rect drawableArea)
        {
            if (notes == null)
                return;

            float min = GetMinVisibleTime();
            float max = GetMaxVisibleTime(drawableArea.width);

            foreach (Note note in notes)
            {
                if (note.start >= max || note.end <= min)
                    continue;
                float start = Mathf.Max(note.start, min);
                float end = Mathf.Min(note.end, max);

                Color color = Color.Lerp(fullCellZeroVelocity, fullCellFullVelocity, note.velocity);
                if (mode == Mode.kDeleting && pressNote == note.note)
                {
                    float pressStart = Mathf.Min(pressTime, dragTime);
                    float pressEnd = Mathf.Max(pressTime, dragTime);

                    if (Utils.RangesOverlap(note.start, note.end, pressStart, pressEnd))
                        color = deletingCell;
                }

                if ((mode != Mode.kDraggingEnd && mode != Mode.kDraggingStart) || activeNote != note)
                    DrawNote(note.note, start / divisionLength, end / divisionLength, color);
            }
        }

        void DrawActiveNotes(Sequencer sequencer, float divisionLength, Rect drawableArea)
        {
            if (sequencer.allNotes == null)
                return;

            int lastKey = GetMaxVisibleKey();
            int firstKey = GetMinVisibleKey(drawableArea.height);

            for (int i = firstKey; i <= lastKey; ++i)
            {
                NoteRow row = sequencer.allNotes[i];
                if (row != null)
                    DrawRowNotes(row.notes, divisionLength, drawableArea);
            }
        }

        void DrawPressedNotes(float divisionLength)
        {
            if (mode == Mode.kDraggingStart)
            {
                DrawNote(activeNote.note, activeTime / divisionLength,
                         activeNote.end / divisionLength, pressedCell);
            }
            else if (mode == Mode.kDraggingEnd)
            {
                DrawNote(activeNote.note, activeNote.start / divisionLength,
                         activeTime / divisionLength, pressedCell);
            }
            else if (mode == Mode.kAdding)
            {
                int startDragIndex = Mathf.Max(0, Mathf.FloorToInt(Mathf.Min(pressTime, dragTime) / divisionLength));
                int endDragIndex = (int)Mathf.Ceil(Mathf.Max(pressTime, dragTime) / divisionLength);

                for (int i = startDragIndex; i < endDragIndex; ++i)
                    DrawNote(pressNote, i, i + 1, pressedCell);
            }
        }

        void DrawPositionOverlay(Sequencer sequencer, Rect drawableArea)
        {
            if (!sequencer.isActiveAndEnabled || !Application.isPlaying)
                return;

            float x = keyboardWidth + colWidth * sequencer.currentIndex;

            GUI.backgroundColor = lightenColor;
            GUI.Box(new Rect(x, scrollPosition.y, colWidth, drawableArea.height), string.Empty);
        }

        public float GetScrollPosition(Sequencer sequencer, float height)
        {
            float lowerBuffer = rowHeight * 8.0f;
            float totalHeight = sequencer.allNotes.Length * rowHeight;

            for (int i = 0; i < sequencer.allNotes.Length; ++i)
            {
                if (sequencer.allNotes[i] != null && sequencer.allNotes[i].notes.Count > 0)
                {
                    float noteY = (sequencer.allNotes.Length - i - 1) * rowHeight;
                    float bottom = Mathf.Clamp(noteY + lowerBuffer, height, totalHeight);
                    return bottom - height;
                }
            }

            return (sequencer.allNotes.Length * rowHeight - height) / 2.0f;
        }

        public float GetMaxHeight()
        {
            return maxRowHeight * (maxKey - minKey + 1);
        }

        Rect GetVelocityRectGlobal(Rect rect)
        {
            int velocityY = Mathf.RoundToInt(rect.height - velocitySectionHeight - bottomPadding + 1);
            return new Rect(rect.x, rect.y + velocityY, rect.width, velocitySectionHeight);
        }

        Rect GetVelocityRect(Rect rect) {
            int velocityY = Mathf.RoundToInt(scrollPosition.y + rect.height - velocitySectionHeight - bottomPadding + 1);
            return new Rect(scrollPosition.x, velocityY, rect.width, velocitySectionHeight);
        }

        int GetMaxVisibleKey()
        {
            return Mathf.Min(maxKey, maxKey - Mathf.FloorToInt(scrollPosition.y / rowHeight));
        }

        int GetMinVisibleKey(float windowHeight)
        {
            int firstKey = minKey - Mathf.CeilToInt((scrollPosition.y + windowHeight) / rowHeight);
            return Mathf.Max(minKey, firstKey);
        }

        public float GetMaxVisibleTime(float windowWidth)
        {
            return (scrollPosition.x + windowWidth - keyboardWidth - rightPadding) / sixteenthWidth;
        }

        public float GetMinVisibleTime()
        {
            return scrollPosition.x / sixteenthWidth;
        }

        float GetMaxVisibleColumn(float windowWidth)
        {
            return (scrollPosition.x + windowWidth - keyboardWidth - rightPadding) / colWidth;
        }

        float GetMinVisibleColumn()
        {
            return scrollPosition.x / colWidth;
        }

        public void DrawSequencer(Rect rect, Sequencer sequencer, float zoomPercent, int allNotes)
        {
            float divisionLength = sequencer.GetDivisionLength();
            numRows = maxKey - minKey + 1;
            numCols = Mathf.RoundToInt(sequencer.length / divisionLength);
            numSixteenths = Mathf.RoundToInt(sequencer.length);

            float zoomLog = Mathf.Log(maxColZoomWidth / minColWidth);
            float zoomSize = minColWidth * Mathf.Exp(zoomLog * zoomPercent);
            float minWidth = Mathf.Max(zoomSize, minColWidth);

            colWidth = Mathf.Max(minWidth * divisionLength, (rect.width - keyboardWidth - rightPadding) / numCols);
            sixteenthWidth = Mathf.Max(minWidth, (rect.width - keyboardWidth - rightPadding) / numSixteenths);

            float noteAreaHeight = rect.height - bottomPadding - velocitySectionHeight;
            //rowHeight = Mathf.Clamp(noteAreaHeight / numRows, minRowHeight, maxRowHeight);
            rowHeight = 100f;
            float scrollableWidth = numCols * colWidth + keyboardWidth + 1;
            float scrollableHeight = numRows * rowHeight + velocitySectionHeight;

            Rect scrollableArea = new Rect(0, 0, scrollableWidth, scrollableHeight);
            if (sequencer.autoScroll && sequencer.isActiveAndEnabled && Application.isPlaying)// && !EditorApplication.isPaused)
            {
                float playPosition = keyboardWidth + colWidth * sequencer.currentIndex;
                scrollPosition = sequencer.scrollPosition;
                if (playPosition < scrollPosition.x - keyboardWidth ||
                    playPosition + colWidth >= scrollPosition.x - keyboardWidth + rect.width)
                {
                    scrollPosition.x = playPosition - keyboardWidth;
                }
                sequencer.scrollPosition = scrollPosition;
            }
            sequencer.scrollPosition = GUI.BeginScrollView(rect, sequencer.scrollPosition, scrollableArea, true, true);
            scrollPosition = sequencer.scrollPosition;

            DrawNoteRows(rect);
            DrawBarHighlights(rect);
            DrawNoteDivisionLines(rect);
            DrawActiveNotes(sequencer, divisionLength, rect);
            DrawPressedNotes(divisionLength);
            DrawPositionOverlay(sequencer, rect);

            velocities.DrawSequencerVelocities(GetVelocityRect(rect), sequencer, GetMinVisibleTime(), GetMaxVisibleTime(rect.width));

            GUI.EndScrollView();
        }
    }
}
//#endif