import React, { useState } from 'react';
import { login } from '../../../api/accounts';
import { jwtDecode } from 'jwt-decode';
import { Link, useNavigate } from 'react-router-dom';
import { ROUTERS } from '../../../utils/router';

const LoginForm = () => {
    const [formData, setFormData] = useState({
        email: '',
        password: '',
    });

    const [error, setError] = useState(null);
    const [success, setSuccess] = useState(null);
    const navigate = useNavigate(); // Access the history object from React Router


    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            let result;
            result = await login({ email: formData.email, password: formData.password });


            if (result.isSuccessful) {
                localStorage.setItem('token', result.data.token); // Store token in localStorage
                const decodedToken = jwtDecode(result.data.token);
                setSuccess('Login successful!');
                setError(null);


                const role = decodedToken.role;
                if (role === 'Admin') {
                    navigate('/admin');
                    window.location.reload();
                    
                } else if (role === 'Expert') {
                    navigate('/expert');
                    window.location.reload();

                } else if (role === 'User') {
                    navigate('/');
                    window.location.reload();

                } else {
                    navigate('/'); // Default redirect if role is not recognized
                }

            } else {
                // Handle errors appropriately
                const errorMessage = result.errors
                    ? result.errors.map(err => <div key={err}>{err}</div>)
                    : result.errorMessage || 'aaa';
                setError(errorMessage);
                setSuccess(null);
            }
        } catch (error) {
            if (error.response && error.response.data && error.response.data.errors) {
                const errorMessages = error.response.data.errors;
                setError(errorMessages);
            } else {
                setError('Invalid email or password.');
            }
            setSuccess(null);
        }
    };

    return (
        <>
        <section className='login-signup-container'>
            <div className="form login">
                <div className="form-content">
                    <header>Login</header>
                    <form onSubmit={handleSubmit}>
                        <div className="field input-field">
                            <input type="email" name="email" value={formData.email} onChange={handleChange} placeholder="Email"
                                required />
                        </div>
                        <div className="field input-field">
                            <input type="password" name="password" value={formData.password} onChange={handleChange}
                                placeholder="Password" required />
                            <i className="bx bx-hide eye-icon" />
                        </div>
                        <div className="form-link">
                            <a href="#" className="forgot-pass">
                                Forgot password?
                            </a>
                        </div>
                        <div className="field button-field">
                            <button type="submit">Login</button>
                        </div>
                        {error && <div className="error">{error}</div>}
                        {success && <div className="success">{success}</div>}
                    </form>
                    <div className="form-link">
                        <span>
                            Don't have an account?{" "}
                            <Link to={ROUTERS.GUEST.REGISTER} className="link signup-link">
                                Signup
                            </Link>
                        </span>
                    </div>
                </div>
                <div className="line" />
                <div className="media-options">
                    <a href="#" className="field google">
                        <img src="img/google.png" alt="" className="google-img" />
                        <span>Login with Google</span>
                    </a>
                </div>
            </div >
            </section>
        </>
    );
};

export default LoginForm;
