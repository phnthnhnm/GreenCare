// components/UserForm.jsx

import React, { useState } from 'react';
import AppointmentsByUser from './userAppointment'

const UserForm = () => {
    const [userId, setUserId] = useState('');
    const [submittedUserId, setSubmittedUserId] = useState(null);

    const handleSubmit = (e) => {
        e.preventDefault();
        setSubmittedUserId(userId);
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <label>
                    User ID:
                    <input
                        type="text"
                        value={userId}
                        onChange={(e) => setUserId(e.target.value)}
                    />
                </label>
                <button type="submit">Get Appointments</button>
            </form>

            {submittedUserId && <AppointmentsByUser userId={submittedUserId} />}
        </div>
    );
};

export default UserForm;
