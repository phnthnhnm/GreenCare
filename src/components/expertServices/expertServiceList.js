import React, { useEffect, useState } from 'react';
import { getAllExpertServices, deleteExpertService } from '../../api/expertServices';
import { Link } from 'react-router-dom';

const ExpertServiceList = () => {
    const [expertServices, setExpertServices] = useState([]);

    useEffect(() => {
        const fetchExpertServices = async () => {
            const data = await getAllExpertServices();
            setExpertServices(data);
        };
        fetchExpertServices();
    }, []);

    const handleDelete = async (expertId, serviceId) => {
        await deleteExpertService(expertId, serviceId);
        setExpertServices(expertServices.filter(es => es.expertId !== expertId && es.serviceId !== serviceId));
    };

    return (
        <div>
            <h1>Expert Services</h1>
            <ul>
                {expertServices.map(es => (
                    <li key={`${es.expertId}-${es.serviceId}`}>
                        {es.expertId} - {es.serviceId}
                        <button onClick={() => handleDelete(es.expertId, es.serviceId)}>Delete</button>
                    </li>
                ))}
            </ul>
            <Link to="/expert-services/new">Add Expert Service</Link>
        </div>
    );
};

export default ExpertServiceList;
