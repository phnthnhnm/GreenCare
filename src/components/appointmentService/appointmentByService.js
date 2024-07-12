import React, { useState } from 'react';
import apiService from '../../api/appointmentService';

const ServiceDetails = () => {
  const [serviceId, setServiceId] = useState('');
  const [appointments, setAppointments] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    try {
      const fetchedServices = await apiService.getAppointmentsByServiceId(serviceId);
      setAppointments(fetchedServices);
      setLoading(false);
    } catch (err) {
      console.error(`Error fetching services for service ID ${serviceId}:`, err);
      setError(err);
      setLoading(false);
    }
  };

  return (
    <div>
      <h2>Service Details</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="serviceID">Service ID:</label>
          <input
            type="text"
            id="serviceId"
            value={serviceId}
            onChange={(e) => setServiceId(e.target.value)}
          />
        </div>
        <button type="submit">Fetch Appointments</button>
      </form>

      {loading && <div>Loading...</div>}
      {error && <div>Error: {error.message}</div>}
      
      <h3>Appointment:</h3>
      <ul>
        {appointments.map((appointment) => (
          <li key={appointment.id}>{appointment.id}</li>
        ))}
      </ul>
    </div>
  );
};

export default ServiceDetails;
