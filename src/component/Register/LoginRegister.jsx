import React, { useState, useRef, useEffect } from 'react';
import {faCheck, faTimes, faInfoCircle} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import './LoginRegister.css';
import { FaUser, FaLock, FaEnvelope } from 'react-icons/fa';

const EMAIL_REGEX =  /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g
const PWD_REGEX =  /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@.#$!%*?&^])[A-Za-z\d@.#$!%*?&]{8,15}$/
const NAME_REGEX =  /^[a-z ,.'-]+$/i



export const LoginRegister = () => {

    const errRef = useRef();

    const [name, setName] = useState('');
    const [validName, setValidName] = useState(false);
    const [nameFocus, setNameFocus] = useState(false);

    const [email, setEmail] = useState('');
    const [validEmail, setValidEmail] = useState(false);
    const [emailFocus, setEmailFocus] = useState(false);

    const [pwd, setPwd] = useState('');
    const [validPwd, setValidPwd] = useState(false);
    const [pwdFocus, setPwdFocus] = useState(false);

    const [matchPwd, setMatchPwd] = useState('');
    const [validMatch, setValidMatch] = useState(false);
    const [matchFocus, setMatchFocus] = useState(false);

    const [errMsg, setErrMsg] = useState('');
    const [success, setSuccess] = useState(false);


    useEffect(() => {
        setValidName(NAME_REGEX.test(name));
    }, [name])

    useEffect(() => {
        setValidPwd(PWD_REGEX.test(pwd));
        setValidMatch(pwd === matchPwd);
    }, [pwd, matchPwd])

    useEffect(() => {
        setValidEmail(EMAIL_REGEX.test(email));
    }, [email])

    useEffect(() => {
        setErrMsg('');
    }, [name, pwd, matchPwd, email])

    const [action, setAction] = useState('');

    const registerLink = () => {
        setAction(' active');
    }

    const loginLink = () => {
        setAction('');
    }

    return (
        <section>
            <div className={`wrapper${action}`}>
                <div className='form-box login'>
                    <form action="">
                        <h1>Login</h1>
                        <div className='input-box'>
                            <input 
                             type="text"
                             placeholder="Email"
                             id="email"
                             autoComplete="off"
                             onChange={(e) => setEmail(e.target.value)}
                             value={email}
                             required
                             aria-invalid={validEmail ? "false" : "true"}
                             aria-describedby="emailnote"
                             onFocus={() => setEmailFocus(true)}
                             onBlur={() => setEmailFocus(false)}
                            />
                            <FaEnvelope className='icon' />
                        </div>
                        
                        <p id="emailnote" className={emailFocus && !validEmail ? "instructions" : "offscreen"}>
                            <FontAwesomeIcon icon={faInfoCircle} />
                            Enter a valid email address that includes an '@' symbol and a domain name (e.g., user@example.com).
                        </p>
                        


                        <div className='input-box'>
                            <input type="password" placeholder='Password' required />
                            <FaLock className='icon' />
                        </div>
                        <div className='remember-forgot'>
                            <label><input type="checkbox" />Remember Me?</label>
                            <a href="#">Forgot Password?</a>
                        </div>
                        <button type='submit'>Login</button>
                        <div className='login-link'>
                            <p>Don't have an account? <a href="#" onClick={registerLink}>Register</a></p>
                        </div>
                    </form>
                </div>

                <p ref={errRef} className={errMsg ? "errmsg" : "offscreen"} aria-live="assertive">{errMsg}</p>

                <div className='form-box register'>
                    <form action="">
                        <h1>Registration</h1>

                        <label htmlFor="email">
                            <FontAwesomeIcon icon={faCheck} className={validEmail ? "valid" : "hide"} />
                            <FontAwesomeIcon icon={faTimes} className={validEmail || !email ? "hide" : "invalid"} />
                        </label>

                        <div className='input-box'>
                            <input 
                             type="text"
                             placeholder="Email"
                             id="email"
                             autoComplete="off"
                             onChange={(e) => setEmail(e.target.value)}
                             value={email}
                             required
                             aria-invalid={validEmail ? "false" : "true"}
                             aria-describedby="emailnote"
                             onFocus={() => setEmailFocus(true)}
                             onBlur={() => setEmailFocus(false)}
                            />
                            <FaEnvelope className='icon' />
                        </div>
                            <p id="emailnote" className={emailFocus && !validEmail ? "instructions" : "offscreen"}>
                                <FontAwesomeIcon icon={faInfoCircle} />
                                Enter a valid email address that includes an '@' symbol and a domain name (e.g., user@example.com).
                            </p>
                        


                        <label htmlFor="name">
                            <FontAwesomeIcon icon={faCheck} className={validName ? "valid" : "hide"} />
                            <FontAwesomeIcon icon={faTimes} className={validName || !name ? "hide" : "invalid"} />
                        </label>    
                        <div className='input-box'>
                            <input 
                            type="text" 
                            placeholder='Name' 
                            autoComplete="off"
                            required
                            id="name"
                            onChange={(e) => setName(e.target.value)}
                            value={name}
                            aria-invalid={validName ? "false" : "true"}
                            aria-describedby="uidnote"
                            onFocus={() => setNameFocus(true)}
                            onBlur={() => setNameFocus(false)}
                        />
                            <FaUser className='icon' />
                        </div>
                        <p id="uidnote" className={nameFocus  && !validName ? "instructions" : "offscreen"}>
                            <FontAwesomeIcon icon={faInfoCircle} />
                            Letters, Space allowed.
                        </p>




                        <label htmlFor="password">
                            <FontAwesomeIcon icon={faCheck} className={validPwd ? "valid" : "hide"} />
                            <FontAwesomeIcon icon={faTimes} className={validPwd || !pwd ? "hide" : "invalid"} />
                        </label>
                        <div className='input-box'>
                            <input 
                                placeholder='Password' 
                                type="password"
                                id="password"
                                onChange={(e) => setPwd(e.target.value)}
                                value={pwd}
                                required
                                aria-invalid={validPwd ? "false" : "true"}
                                aria-describedby="pwdnote"
                                onFocus={() => setPwdFocus(true)}
                                onBlur={() => setPwdFocus(false)}
                            />
                            <FaLock className='icon' />
                        </div>
                        <p id="pwdnote" className={pwdFocus && !validPwd ? "instructions" : "offscreen"}>
                            <FontAwesomeIcon icon={faInfoCircle} />
                            8 to 24 characters.<br />
                            Must include uppercase and lowercase letters, a number and a special character.<br />
                            Allowed special characters: <span aria-label="exclamation mark">!</span> <span aria-label="at symbol">@</span> <span aria-label="hashtag">#</span> <span aria-label="dollar sign">$</span> <span aria-label="percent">%</span>
                        </p>


                        <label htmlFor="confirm_pwd">
                            <FontAwesomeIcon icon={faCheck} className={validMatch && matchPwd ? "valid" : "hide"} />
                            <FontAwesomeIcon icon={faTimes} className={validMatch || !matchPwd ? "hide" : "invalid"} />
                        </label>
                        <div className='input-box'>
                            <input 
                                type="password" 
                                placeholder='Password Confirmation' 
                                required
                                id="confirm_pwd"
                                onChange={(e) => setMatchPwd(e.target.value)}
                                value={matchPwd}
                                aria-invalid={validMatch ? "false" : "true"}
                                aria-describedby="confirmnote"
                                onFocus={() => setMatchFocus(true)}
                                onBlur={() => setMatchFocus(false)} 
                            />
                            <FaLock className='icon' />
                        </div>
                        <p id="confirmnote" className={matchFocus && !validMatch ? "instructions" : "offscreen"}>
                            <FontAwesomeIcon icon={faInfoCircle} />
                            Must match the first password input field.
                        </p>

                        <button type='submit'>Register</button>
                        <div className='login-link'>
                            <p>Already have an account? <a href="#" onClick={loginLink}>Login</a></p>
                        </div>
                    </form>
                </div>
            </div>
        </section>
    );
};
