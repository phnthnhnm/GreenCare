import React, { useEffect, useState } from 'react';
import { getAllPlantCareLogs, deletePlantCareLog } from '../../api/plantCareLogs';
import { Link } from 'react-router-dom';

const PlantCareLogList = () => {
    const [plantCareLogs, setPlantCareLogs] = useState([]);

    useEffect(() => {
        const fetchPlantCareLogs = async () => {
            const data = await getAllPlantCareLogs();
            setPlantCareLogs(data);
        };
        fetchPlantCareLogs();
    }, []);

    const handleDelete = async (id) => {
        await deletePlantCareLog(id);
        setPlantCareLogs(plantCareLogs.filter(log => log.id !== id));
    };

    return (
        <div>
            <h1>Plant Care Logs</h1>
            <ul>
                {plantCareLogs.map(log => (
                    <li key={log.appointmentId}>
                        {log.expertId} - {log.notes} - {log.date}
                        <button onClick={() => handleDelete(log.id)}>Delete</button>
                        <Link to={`/plant-care-logs/${log.id}/edit`}>Edit</Link>
                    </li>
                ))}
            </ul>
            <Link to="/plant-care-logs/new">Add Plant Care Log</Link>
        </div>
    );
};

export default PlantCareLogList;
