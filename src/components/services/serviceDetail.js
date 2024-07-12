/* import React, { useEffect, useState } from 'react';
import { getServiceById } from '../../api/services';
import { useParams } from 'react-router-dom';

const ServiceDetail = () => {
    const { id } = useParams();
    const [service, setService] = useState(null);

    useEffect(() => {
        const fetchService = async () => {
            const data = await getServiceById(id);
            setService(data);
        };
        fetchService();
    }, [id]);

    return (
        <div>
            {service ? (
                <>
                    <h1>{service.name}</h1>
                    <p>{service.description}</p>
                </>
            ) : (
                <p>Loading...</p>
            )}
        </div>
    );
};

export default ServiceDetail;
 */