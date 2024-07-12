import React, { useEffect, useState } from 'react';
import { getAllPayments, deletePayment } from '../../api/payments';
import { Link } from 'react-router-dom';

const PaymentList = () => {
    const [payments, setPayments] = useState([]);

    useEffect(() => {
        const fetchPayments = async () => {
            const data = await getAllPayments();
            setPayments(data);
        };
        fetchPayments();
    }, []);

    const handleDelete = async (id) => {
        await deletePayment(id);
        setPayments(payments.filter(payment => payment.id !== id));
    };

    return (
        <div>
            <h1>Payments</h1>
            <ul>
                {payments.map(payment => (
                    <li key={payment.id}>
                        <p><strong>Payment ID:</strong> {payment.id}</p>
                        <p><strong>Amount:</strong> {payment.amount}</p>
                        <p><strong>Payment Method:</strong> {payment.paymentMethod}</p>
                        <p><strong>Date:</strong> {payment.dateTime}</p>
                        <p><strong>Status:</strong> {payment.status}</p>
                        <button onClick={() => handleDelete(payment.id)}>Delete</button>
                        <Link to={`/payments/${payment.id}/edit`}>Edit</Link>
                    </li>
                ))}
            </ul>
            <Link to="/payments/new">Add Payment</Link>
        </div>
    );
};

export default PaymentList;
