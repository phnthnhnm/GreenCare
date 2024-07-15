import { memo, useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { ROUTERS } from '../../../utils/router';
import { jwtDecode } from 'jwt-decode';

const Logout = () =>{
    const [user, setUser] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        // Example: Fetch user data from localStorage or an API
        const token = localStorage.getItem('token');
        const decodedToken = jwtDecode(token);
        if (decodedToken) {
            setUser(decodedToken);
        }
    }, []);


    // Perform logout logic, e.g., clearing localStorage and redirecting
    localStorage.removeItem('token');
    setUser(null);
    navigate(ROUTERS.GUEST.LOGIN);

}
export default memo(Logout);