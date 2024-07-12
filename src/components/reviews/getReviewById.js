import React, { useState } from 'react';
import { getReviewById } from '../../api/review';

const ReviewDetails = () => {
    const [id, setId] = useState('');
    const [review, setReview] = useState(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const handleChange = (e) => {
        setId(e.target.value);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        setError(null);
        try {
            const data = await getReviewById(id);
            setReview(data);
        } catch (err) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h2>Find Review by ID</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Enter Review ID"
                    value={id}
                    onChange={handleChange}
                />
                <button type="submit">Find</button>
            </form>
            {loading && <div>Loading...</div>}
            {error && <div>Error: {error.message}</div>}
            {review && (
                <div>
                    <h3>Review Details</h3>
                    <p><strong>ID:</strong> {review.id}</p>
                    <p><strong>Reviewer Name:</strong> {review.userId}</p>
                    <p><strong>Reviewer Name:</strong> {review.serviceId}</p>
                    <p><strong>Rating:</strong> {review.rating}</p>
                    <p><strong>Comment:</strong> {review.comment}</p>
                    <p><strong>Date:</strong> {review.dateTime}</p>
                </div>
            )}
        </div>
    );
};

export default ReviewDetails;
