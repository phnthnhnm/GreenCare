import { memo } from 'react';
import React, { useState, useEffect } from 'react';
import { getAllReviews } from '../../../api/review';

const Review = () => {
  const [reviews, setReviews] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

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
            ID: {review.id}<br />
            UserID: {review.userId}<br />
            serviceID: {review.serviceId}<br />
            Rating: {review.rating}<br />
            Comment: {review.comment}<br />
            Date: {review.dateTime}<br />
          </li>
        ))}
      </ul>
    </div>
  )
}

export default memo(Review);