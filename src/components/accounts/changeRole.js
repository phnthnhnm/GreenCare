import React, { useState } from 'react';
import { changeRole } from '../../api/accounts';

const ChangeRole = () => {
    const [formData, setFormData] = useState({
        userId: '',
        role: ''
    });

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const result = await changeRole(formData.userId, formData.role);
            console.log('Role changed successfully', result);
        } catch (error) {
            console.error('Failed to change role', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <input name="userId" placeholder="User ID" onChange={handleChange} value={formData.userId} />
            <input name="role" placeholder="Role" onChange={handleChange} value={formData.role} />
            <button type="submit">Change Role</button>
        </form>
    );
};

export default ChangeRole;
