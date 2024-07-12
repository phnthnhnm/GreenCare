// components/reviews/ReviewForm.jsx

import React, { useState, useEffect } from 'react';
import { createReview, updateReview, getReviewById } from '../../api/review';
import { useNavigate, useParams } from 'react-router-dom';

const ReviewForm = ({ isEditMode }) => {
    const [formData, setFormData] = useState({
        userId: '',
        serviceId: 0,
        rating: 0,
        comment: '',
        dateTime: '',
    });
    
    const navigate = useNavigate();
    const { id } = useParams();

    useEffect(() => {
        if (isEditMode && id) {
            const fetchReview = async () => {
                try {
                    const data = await getReviewById(id);
                    setFormData(data);
                } catch (error) {
                    console.error('Error fetching review:', error);
                }
            };
            fetchReview();
        }
    }, [isEditMode, id]);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            if (isEditMode) {
                await updateReview(id, formData);
                console.log('Review updated successfully');
            } else {
                await createReview(formData);
                console.log('Review created successfully');
            }
            navigate('/reviews');
        } catch (error) {
            console.error('Error:', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label htmlFor="userId">User ID</label>
                <input
                    id="userId"
                    name="userId"
                    placeholder="User ID"
                    onChange={handleChange}
                    value={formData.userId}
                />
            </div>
            <div>
                <label htmlFor="serviceId">Service ID</label>
                <input
                    id="serviceId"
                    name="serviceId"
                    type="number"
                    placeholder="Service ID"
                    onChange={handleChange}
                    value={formData.serviceId}
                />
            </div>
            <div>
                <label htmlFor="rating">Rating</label>
                <input
                    id="rating"
                    name="rating"
                    type="number"
                    min="1"
                    max="5"
                    placeholder="Rating"
                    onChange={handleChange}
                    value={formData.rating}
                />
            </div>
            <div>
                <label htmlFor="comment">Comment</label>
                <textarea
                    id="comment"
                    name="comment"
                    placeholder="Comment"
                    onChange={handleChange}
                    value={formData.comment}
                />
            </div>
            <div>
                <label htmlFor="dateTime">Date</label>
                <input
                    id="dateTime"
                    name="dateTime"
                    type="datetime-local"
                    placeholder="Date"
                    onChange={handleChange}
                    value={formData.dateTime}
                />
            </div>
            <button type="submit">{isEditMode ? 'Update Review' : 'Create Review'}</button>
        </form>
    );
};

export default ReviewForm;      