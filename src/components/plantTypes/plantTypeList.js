import React, { useEffect, useState } from 'react';
import { getAllPlantTypes, deletePlantType } from '../../api/plantType';
import { Link } from 'react-router-dom';

const PlantTypeList = () => {
    const [plantTypes, setPlantTypes] = useState([]);

    useEffect(() => {
        const fetchPlantTypes = async () => {
            const data = await getAllPlantTypes();
            setPlantTypes(data);
        };
        fetchPlantTypes();
    }, []);

    const handleDelete = async (id) => {
        await deletePlantType(id);
        setPlantTypes(plantTypes.filter(pt => pt.id !== id));
    };

    return (
        <div>
            <h1>Plant Types</h1>
            <ul>
                {plantTypes.map(pt => (
                    <li key={pt.id}>
                        {pt.id} - {pt.name} -
                        <button onClick={() => handleDelete(pt.id)}> Delete</button> -
                        <Link to={`/plant-types/${pt.id}/edit`}>Edit</Link>
                    </li>
                ))}
            </ul>
            <Link to="/plant-types/new">Add Plant Type</Link>
        </div>
    );
};

export default PlantTypeList;
