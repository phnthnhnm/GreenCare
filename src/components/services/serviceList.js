import React, { useEffect, useState } from 'react';
import { getAllServices,deleteService } from '../../api/services';
import { Link } from 'react-router-dom';
const ServiceList = () => {
    const [services, setServices] = useState([]);

    useEffect(() => {
        const fetchServices = async () => {
            const data = await getAllServices();
            setServices(data);
        };
        fetchServices();
    }, []);

    const handleDelete = async (id) => {
        await deleteService(id);
        setServices(services.filter(services => services.id !== id));
    };

    return (
        <div>
            <h1>Services</h1>
            <ul>
                {services.map(service => (
                    <li key={service.id}>
                        Name: {service.name}<br/>
                        Desc: {service.description}<br/>
                        Price: {service.price}<br/>
                        Duration: {service.duration}<br/>
                        <button onClick={() => handleDelete(service.id)}>Delete</button>
                        <Link to={`/services/${service.id}/edit`}>Edit</Link>
                    </li>
                ))}
            </ul>

        </div>
    );
};

export default ServiceList;
