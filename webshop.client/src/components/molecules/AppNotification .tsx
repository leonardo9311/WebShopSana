// src/components/molecules/AppNotification.tsx
import React from 'react';
import './Notification.css'; // Assuming you have some CSS for styling

interface NotificationProps {
    message: string;
    type: 'success' | 'error' | 'info' | 'warning';
    onClose: () => void;
}

const AppNotification: React.FC<NotificationProps> = ({ message, type, onClose }) => {
    return (
        <div className={`notification notification--${type}`}>
            <span>{message}</span>
            <button onClick={onClose} aria-label="Close notification">X</button>
        </div>
    );
};

export default AppNotification;
