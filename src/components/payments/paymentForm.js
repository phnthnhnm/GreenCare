import React, { useState, useEffect } from 'react';
import { createPayment, getPaymentById, updatePayment } from '../../api/payments';
import { useNavigate, useParams } from 'react-router-dom';

const PaymentForm = ({ isEditMode }) => {
    const [formData, setFormData] = useState({
        amount: '',
        dateTime: '',
        appointmentId: '', // New attribute for appointment ID
        paymentMethod: '', // New attribute for payment method
        status: 'Pending', // New attribute for status with default value
    });

    const navigate = useNavigate();
    const { id } = useParams();

    useEffect(() => {
        if (isEditMode) {
            const fetchPayment = async () => {
                try {
                    const payment = await getPaymentById(id);
                    setFormData(payment);
                } catch (error) {
                    console.error('Error fetching payment:', error);
                }
            };
            fetchPayment();
        }
    }, [id, isEditMode]);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            if (isEditMode) {
                await updatePayment(id, formData);
            } else {
                await createPayment(formData);
            }
            navigate('/payments');
        } catch (error) {
            console.error('Error:', error);
        }
    };

    return (
        <div>
            <h2>{isEditMode ? 'Edit Payment' : 'Create Payment'}</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="amount">Amount:</label>
                    <input
                        type="number"
                        name="amount"
                        placeholder="Amount"
                        onChange={handleChange}
                        value={formData.amount}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="dateTime">Date:</label>
                    <input
                        type="datetime-local"
                        name="dateTime"
                        placeholder="Date"
                        onChange={handleChange}
                        value={formData.dateTime}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="appointmentId">Appointment ID:</label>
                    <input
                        type="text"
                        name="appointmentId"
                        placeholder="Appointment ID"
                        onChange={handleChange}
                        value={formData.appointmentId}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="paymentMethod">Payment Method:</label>
                    <select
                        name="paymentMethod"
                        onChange={handleChange}
                        value={formData.paymentMethod}
                        required
                    >
                        <option value="">Select Payment Method</option>
                        <option value="Card">Card</option>
                        <option value="Cash">Cash</option>
                    </select>
                </div>
                <div>
                    <label htmlFor="status">Status:</label>
                    <select
                        name="status"
                        onChange={handleChange}
                        value={formData.status}
                        required
                    >
                        <option value="Pending">Pending</option>
                        <option value="Completed">Completed</option>
                        <option value="Cancelled">Cancelled</option>
                    </select>
                </div>
                <button type="submit">{isEditMode ? 'Update Payment' : 'Create Payment'}</button>
            </form>
        </div>
    );
};

export default PaymentForm;
