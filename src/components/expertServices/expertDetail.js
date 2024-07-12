import React, { useState } from 'react';
import { getExpertsByServiceId } from '../../api/expertServices';

const ExpertDetails = () => {
    const [serviceId, setServiceId] = useState('');
    const [experts, setExperts] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        setError(null);

        try {
            const fetchedExperts = await getExpertsByServiceId(serviceId);
            setExperts(fetchedExperts);
        } catch (err) {
            setError(err);
            console.error(`Error fetching experts for service ID ${serviceId}:`, err);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h2>Fetch Experts by Service ID</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="serviceId">Service ID:</label>
                    <input
                        type="text"
                        id="serviceId"
                        value={serviceId}
                        onChange={(e) => setServiceId(e.target.value)}
                    />
                </div>
                <button type="submit">Fetch Experts</button>
            </form>

            {loading && <div>Loading...</div>}
            {error && <div>Error: {error.message}</div>}

            {!loading && !error && (
                <div>
                    <h3>Experts:</h3>
                    <ul>
                        {experts.map((expert) => (
                            <li key={expert.email}>
                                <strong>{expert.email}</strong>
                            </li>
                        ))}
                    </ul>
                </div>
            )}
        </div>
    );
};

export default ExpertDetails;
    