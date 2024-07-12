import axios from 'axios';

const API_URL = 'http://localhost:5062/api/reviews';

export const getAllReviews = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const getReviewById = async (id) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
};

export const createReview = async (review) => {
    const response = await axios.post(API_URL, review);
    return response.data;
};

export const updateReview = async (id, review) => {
    const response = await axios.put(`${API_URL}/${id}`, review);
    return response.data;
};

export const deleteReview = async (id) => {
    await axios.delete(`${API_URL}/${id}`);
};
