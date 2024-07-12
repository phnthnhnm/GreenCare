import React, { useState } from 'react';
import { login, register } from '../../../api/accounts';
import { jwtDecode } from 'jwt-decode';
import { useNavigate } from 'react-router-dom';


const LoginSignupForm = ({ isLogin }) => {
  const [formData, setFormData] = useState({
    email: '',
    password: '',
    confirmPassword: '',
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

    // Validation for matching passwords
    if (!isLogin && formData.password !== formData.confirmPassword) {
      setError('Passwords do not match');
      return;
    }

    try {
      let result;
      if (isLogin) {
        result = await login({ email: formData.email, password: formData.password });
      } else {
        // Remove confirmPassword from formData before sending to register API
        const { confirmPassword, ...registerData } = formData;
        result = await register(registerData);
      }

      if (result.isSuccessful) {
        if (isLogin) {
          localStorage.setItem('token', result.data.token); // Store token in localStorage
          const decodedToken = jwtDecode(result.data.token);
          setSuccess('Login successful!');
          setError(null);


          const role = decodedToken.role;
          if (role === 'Admin') {
            navigate('/admin');
          } else if (role === 'Expert') {
            navigate('/expert');
          } else if (role === 'User') {
            navigate('/');
          } else {
            navigate('/'); // Default redirect if role is not recognized
          }

        } else {
          setSuccess('Registration successful!');
        }

        setError(null);
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
        setError('An error occurred during login.');
      }
      setSuccess(null);
    }
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          name="email"
          value={formData.email}
          onChange={handleChange}
          placeholder="email"
          required
        />
        <input
          type="password"
          name="password"
          value={formData.password}
          onChange={handleChange}
          placeholder="Password"
          required
        />
        {!isLogin && (
          <>
            <input
              type="password"
              name="confirmPassword"
              value={formData.confirmPassword}
              onChange={handleChange}
              placeholder="Confirm Password"
              required
            />
          </>
        )}
        <button type="submit">{isLogin ? 'Login' : 'Register'}</button>
        {error && <div className="error">{error}</div>}
        {success && <div className="success">{success}</div>}
      </form>
    </div>
  );
};

export default LoginSignupForm;
