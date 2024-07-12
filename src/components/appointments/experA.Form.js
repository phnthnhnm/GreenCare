// components/ExpertForm.jsx

import React, { useState } from 'react';
import AppointmentsByExpert from './expertAppointment';

const ExpertForm = () => {
    const [expertId, setExpertId] = useState('');
    const [submittedExpertId, setSubmittedExpertId] = useState(null);

    const handleSubmit = (e) => {
        e.preventDefault();
        setSubmittedExpertId(expertId);
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <label>
                    Expert ID:
                    <input
                        type="text"
                        value={expertId}
                        onChange={(e) => setExpertId(e.target.value)}
                    />
                </label>
                <button type="submit">Get Appointments</button>
            </form>

            {submittedExpertId && <AppointmentsByExpert expertId={submittedExpertId} />}
        </div>
    );
};

export default ExpertForm;
