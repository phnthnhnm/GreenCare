import { memo, useEffect, useState } from 'react';
import { createAppointment } from '../../../api/appointments';
import { getExpertsByServiceId } from '../../../api/expertServices';
import { getServiceById } from '../../../api/services';
import { useLocation } from 'react-router-dom';


const BookingView = () => {

  const [experts, setExperts] = useState([]);
  const [service, setService] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const location = useLocation();

  const { id } = location.state || {};

  useEffect(() => {
    const fetchService = async () => {
      try {
        if (!id) {
          throw new Error('Service ID not provided');
        }
        const serviceData = await getServiceById(id);
        setService(serviceData);
        const expertsData = await getExpertsByServiceId(id);
        setExperts(expertsData);
      } catch (err) {
        setError(err.message || 'Error fetching data.');
      } finally {
        setLoading(false);
      }
    };
    fetchService();
  }, [id]);

  if (loading) return <div>Loading...</div>;
  if (error) return <div>{error}</div>;


  return (
    <div>
      <h1>Book Service</h1>
      {service ? (
        <div>
          <h2>{service.name}</h2>
          <p>Price: ${service.price}</p>
          <p>Duration: {service.duration} minutes</p>
        </div>
      ) : (
        <div>No service details available.</div>
      )}

      {experts.length > 0 ? (
        experts.map((expert) => (
          <div key={expert.id}>
            <h2>{expert.name}</h2>
            <p>Email: {expert.email}</p>
            <p>Expertise: {expert.expertise}</p>
            <p>Experience: {expert.experience} years</p>
          </div>
        ))
      ) : (
        <p>No experts available for this service.</p>
      )}
    </div>
  );
};


export default memo( BookingView );