// components/reviews/ReviewList.jsx

import React, { useState, useEffect } from 'react';
import { getAllReviews, deleteReview } from '../../api/review';
import { Link, useNavigate } from 'react-router-dom';

const ReviewList = () => {
    const [reviews, setReviews] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState('');
    const navigate = useNavigate();

    useEffect(() => {
        const fetchReviews = async () => {
            try {
                const data = await getAllReviews();
                setReviews(data);
            } catch (error) {
                setError(`Error fetching reviews: ${error.message}`);
            } finally {
                setLoading(false);
            }
        };
        fetchReviews();
    }, []);

    const handleDelete = async (id) => {
        try {
            await deleteReview(id);
            setReviews(reviews.filter((review) => review.id !== id));
            alert('Review deleted successfully!');
        } catch (error) {
            console.error('Error deleting review:', error);
            alert('Failed to delete review. Please try again.');
        }
    };

    if (loading) {
        return <p>Loading...</p>;
    }

    if (error) {
        return <p>{error}</p>;
    }

    return (
        <div>
            <h2>Reviews</h2>
            <ul>
                {reviews.map((review) => (
                    <li key={review.id}>
                        ID: {review.id}<br/>
                        UserID: {review.userId}<br/>
                        serviceID: {review.serviceId}<br/>
                        Rating: {review.rating}<br/>
                        Comment: {review.comment}<br/>
                        Date: {review.dateTime}<br/>
                        <button onClick={() => navigate(`/reviews/${review.id}/edit`)}>Edit</button>
                        <button onClick={() => handleDelete(review.id)}>Delete</button>
                    </li>
                ))}
            </ul>
            <Link to="/reviews/new">Create Review</Link>
        </div>
    );
};

export default ReviewList;
