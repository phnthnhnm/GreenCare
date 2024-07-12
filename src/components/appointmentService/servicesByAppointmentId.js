import React, { useState } from 'react';
import apiService from '../../api/appointmentService';


const AppointmentDetails = () => {
  const [appointmentId, setAppointmentId] = useState('');
  const [services, setServices] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    try {
      const fetchedServices = await apiService.getServicesByAppointmentId(appointmentId);
      setServices(fetchedServices);
      setLoading(false);
    } catch (err) {
      console.error(`Error fetching services for appointment ID ${appointmentId}:`, err);
      setError(err);
      setLoading(false);
    }
  };

  return (
    <div>
      <h2>Appointment Details</h2>
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
        <button type="submit">Fetch Services</button>
      </form>

      {loading && <div>Loading...</div>}
      {error && <div>Error: {error.message}</div>}
      
      <h3>Services:</h3>
      <ul>
        {services.map((service) => (
          <li key={service.id}>{service.name}</li>
        ))}
      </ul>
    </div>
  );
};

export default AppointmentDetails;
