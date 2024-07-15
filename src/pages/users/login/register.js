import React, { useState } from 'react';
import { register } from '../../../api/accounts';
import { Link } from 'react-router-dom';
import { ROUTERS } from '../../../utils/router';

const SignupForm = () => {
  const [formData, setFormData] = useState({
    email: '',
    password: '',
    confirmPassword: '',
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

    // Validation for matching passwords
    if (formData.password !== formData.confirmPassword) {
      setError('Passwords do not match');
      return;
    }

    try {
      let result;

      // Remove confirmPassword from formData before sending to register API
      const { confirmPassword, ...registerData } = formData;
      result = await register(registerData);


      if (result.isSuccessful) {
        setSuccess('Registration successful!');
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
        setError('Invalid Email address.');
      }
      setSuccess(null);
    }
  };

  return (
    <>
    <br/>
      <section className='login-signup-container'>
          <div className="form signup">
          <div className="form-content">
            <header>Sign Up</header>
            <form onSubmit={handleSubmit}>
              <div className="field input-field">
                <input
                  type="text"
                  name="email"
                  value={formData.email}
                  onChange={handleChange}
                  placeholder="Email"
                  required
                />
                <div className="error" />
              </div>
              <div className="field input-field">
                <input
                  type="password"
                  name="password"
                  value={formData.password}
                  onChange={handleChange}
                  placeholder="Password"
                  required
                />
                <div className="error" />
              </div>
              <div className="field input-field">
                <input
                  type="password"
                  name="confirmPassword"
                  value={formData.confirmPassword}
                  onChange={handleChange}
                  placeholder="Confirm Password"
                  required
                />
                <i className="bx bx-hide eye-icon" />
                <div className="error" />
              </div>
              <div className="field button-field">
                <button type='submit'>Sign Up</button>
              </div>
                {error && <div className="field input-field error-field">{error}</div>}
                {success && <div className="field input-field success-field">{success}</div>}
            </form>

            <br/><br/>
            <div className="form-link">
              <span>
                Already have an account?{" "}
                <Link to={ROUTERS.GUEST.LOGIN} className="link login-link">
                  Login
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
        </div>
      </section>
    </>
  );
};

export default SignupForm;
