// src/components/organisms/NotificationContainer.tsx
import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { RootState } from '../../store/store';
import { clearNotification } from '../../store/reducers/notificationSlice';
import Notification from './AppNotification '; // Import the Notification component

const NotificationContainer: React.FC = () => {
    const dispatch = useDispatch();
    const notification = useSelector((state: RootState) => state.notification);

    if (!notification.message) return null;

    return (
        <Notification
            message={notification.message}
            type={notification.type as 'success' | 'error' | 'info' | 'warning'}
            onClose={() => dispatch(clearNotification())}
        />
    );
};

export default NotificationContainer;
