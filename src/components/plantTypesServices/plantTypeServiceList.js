
import React, { useEffect, useState } from 'react';
import { getAllPlantTypeServices, deletePlantTypeService } from '../../api/plantTypeServices';
import { Link } from 'react-router-dom';

const PlantTypeServiceList = () => {
    const [plantTypeServices, setPlantTypeServices] = useState([]);

    useEffect(() => {
        const fetchPlantTypeServices = async () => {
            const data = await getAllPlantTypeServices();
            setPlantTypeServices(data);
        };
        fetchPlantTypeServices();
    }, []);

    const handleDelete = async (plantTypeId, serviceId) => {
        await deletePlantTypeService(plantTypeId, serviceId);
        setPlantTypeServices(plantTypeServices.filter(pts => !(pts.plantTypeId === plantTypeId && pts.serviceId === serviceId)));
    };

    return (
        <div>
            <h1>Plant Type Services</h1>
            <ul>
                {plantTypeServices.map(pts => (
                    <li key={`${pts.plantTypeId}-${pts.serviceId}`}>
                        Plant Type ID: {pts.plantTypeId} - Service ID: {pts.serviceId}
                        <button onClick={() => handleDelete(pts.plantTypeId, pts.serviceId)}>Delete</button>
                    </li>
                ))}
            </ul>
            <Link to="/plant-type-services/new">Add Plant Type Service</Link>
        </div>
    );
};

export default PlantTypeServiceList;
