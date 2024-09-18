
import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface NotificationState {
    message: string | null;
    type: 'success' | 'error' | 'info' | 'warning' | null;
}

const initialState: NotificationState = {
    message: null,
    type: null,
};

const notificationSlice = createSlice({
    name: 'notification',
    initialState,
    reducers: {
        setNotification: (state, action: PayloadAction<{ message: string; type: 'success' | 'error' | 'info' | 'warning' }>) => {
            state.message = action.payload.message;
            state.type = action.payload.type;
        },
        clearNotification: (state) => {
            state.message = null;
            state.type = null;
        },
    },
});

export const { setNotification, clearNotification } = notificationSlice.actions;

export default notificationSlice.reducer;
