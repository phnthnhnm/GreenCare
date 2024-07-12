import React, { useState } from 'react';
import { register } from '../../api/accounts';

const RegisterForm = () => {
    const [formData, setFormData] = useState({
        username: '',
        password: '',
        email: '',
    });
    const [error, setError] = useState(null);
    const [success, setSuccess] = useState(null);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const result = await register(formData);
            if (result.isSuccessful) {
                setSuccess('Registration successful!');
            } else {
                setError(result.errors);
            }
        } catch (error) {
            setError('An error occurred during registration.');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <input type="text" name="username" value={formData.username} onChange={handleChange} placeholder="Username" required />
            <input type="password" name="password" value={formData.password} onChange={handleChange} placeholder="Password" required />
            <input type="email" name="email" value={formData.email} onChange={handleChange} placeholder="Email" required />
            <button type="submit">Register</button>
            {error && <div className="error">{error}</div>}
            {success && <div className="success">{success}</div>}
        </form>
    );
};

export default RegisterForm;
