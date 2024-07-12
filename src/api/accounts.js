// src/services/apiService.js
import axios from "axios";
const BASE_URL = 'http://localhost:5062/api/accounts';


export const getAllUsers = async () => {
    try {
        const response = await axios.get(`${BASE_URL}`);
        return response.data;
    } catch (error) {
        throw error;
    }
};


const register = async (registerDto) => {
    try {
        const response = await axios.post(`${BASE_URL}/register`, registerDto);
        return {
            isSuccessful: response.status === 200,
            data: response.data,
        };
    } catch (error) {
        return {
            isSuccessful: false,
            errors: error.response ? error.response.data : 'Network Error',
        };
    }
};

const login = async (loginData) => {
    try {
        const response = await axios.post(`${BASE_URL}/login`, loginData);
        return {
            isSuccessful: response.status === 200,
            data: response.data,
        }
    } catch (error) {   
        return {
            isSuccessful: false,
            errors: error.response ? error.response.data : 'Network Error',
        };
    }
};

const changeRole = async (id, role) => {
    const response = await fetch(`${BASE_URL}/${id}/change-role?role=${role}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
    });
    return await response.json();
};

const deleteUser = async (id) => {
    const response = await fetch(`${BASE_URL}/${id}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
    });
    return await response.json();
};

export { register, login, changeRole, deleteUser };
