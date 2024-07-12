import { memo, useEffect, useState } from 'react';
import { getAllServices } from '../../../api/services';

const Services = () => {
  const [services, setServices] = useState([]);

    useEffect(() => {
        const fetchServices = async () => {
            const data = await getAllServices();
            setServices(data);
        };
        fetchServices();
    }, []);


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
                    </li>
                ))}
            </ul>

        </div>
    );
}

export default memo(Services);