import React, { useState } from 'react';
import { getPaymentById } from '../../api/payments';

const PaymentDetails = () => {
    const [id, setId] = useState('');
    const [payment, setPayment] = useState(null);
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
            const data = await getPaymentById(id);
            setPayment(data);
        } catch (err) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h2>Find Payment by ID</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Enter Payment ID"
                    value={id}
                    onChange={handleChange}
                />
                <button type="submit">Find</button>
            </form>
            {loading && <div>Loading...</div>}
            {error && <div>Error: {error.message}</div>}
            {payment && (
                <div>
                    <h3>Payment Details</h3>
                    <p><strong>ID:</strong> {payment.id}</p>
                    <p><strong>AppointmentID:</strong> {payment.appointmentId}</p>
                    <p><strong>Amount:</strong> {payment.amount}</p>
                    <p><strong>Method:</strong> {payment.paymentMethod}</p>
                    <p><strong>dateTime:</strong> {payment.dateTime}</p>
                    <p><strong>Status:</strong> {payment.Status}</p>
                </div>
            )}
        </div>
    );
};

export default PaymentDetails;
