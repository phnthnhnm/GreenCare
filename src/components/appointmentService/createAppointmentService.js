import React, { useState } from 'react';
import apiService from '../../api/appointmentService';

const CreateAppointmentService = () => {
  const [appointmentId, setAppointmentId] = useState('');
  const [serviceId, setServiceId] = useState('');
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      setLoading(true);
      const response = await apiService.createAppointmentService({
        appointmentId,
        serviceId,
      });
      setLoading(false);
      console.log('Created appointment service:', response.data);
      // Optionally reset form fields or handle success state
    } catch (err) {
      setLoading(false);
      console.error('Error creating appointment service:', err);
      setError(err);
    }
  };

  return (
    <div>
      <h2>Create Appointment Service</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="appointmentId">Appointment ID:</label>
          <input
            type="text"
            id="appointmentId"
            value={appointmentId}
            onChange={(e) => setAppointmentId(e.target.value)}
          />
        </div>
        <div>
          <label htmlFor="serviceId">Service ID:</label>
          <input
            type="text"
            id="serviceId"
            value={serviceId}
            onChange={(e) => setServiceId(e.target.value)}
          />
        </div>
        {loading ? (
          <div>Loading...</div>
        ) : (
          <button type="submit">Create Appointment Service</button>
        )}
        {error && <div>Error: {error.message}</div>}
      </form>
    </div>
  );
};

export default CreateAppointmentService;
