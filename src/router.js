import React from 'react';
import { Routes, Route } from 'react-router-dom';
import { ROUTERS } from "./utils/router";
import Home from "./pages/users/home/Home";
import MasterLayout from "./pages/users/layout/Layout";
import ExpertLayout from "./pages/expert/layout/Layout";
import AdminLayout from "./pages/admin/layout/Layout";
import LoginSignupForm from "./pages/users/login/register-login";
import Expert from "./pages/expert/expert";
import Admin from "./pages/admin/admin";
import About from './pages/users/about/about';
import Review from './pages/users/review/review';
import Service from './pages/users/service/service';
import Contact from './pages/users/contact/contact';
import ExpertUserView from './pages/users/expert/expert';
import BookingView from './pages/users/booking/booking';


const userRoutes = (routes) => {
    return (
        <MasterLayout>
            <Routes>
                {routes.map((item, key) => (
                    <Route key={key} path={item.path} element={item.component} />
                ))}
            </Routes>
        </MasterLayout>
    );
};

const expertRoutes = (routes) => {
    return (
        <ExpertLayout>
            <Routes>
                {routes.map((item, key) => (
                    <Route key={key} path={item.path} element={item.component} />
                ))}
            </Routes>
        </ExpertLayout>
    );
};

const adminRoutes = (routes) => {
    return (
        <AdminLayout>
            <Routes>
                {routes.map((item, key) => (
                    <Route key={key} path={item.path} element={item.component} />
                ))}
            </Routes>
        </AdminLayout>
    );
};

const guestRoutes = (routes) => {
    return (
        <MasterLayout>
            <Routes>
                {routes.map((item, key) => (
                    <Route key={key} path={item.path} element={item.component} />
                ))}
            </Routes>
        </MasterLayout>
    );
};

const RouterCustom = () => {
    const userRouters = [
        { path: ROUTERS.USER.HOME, component: <Home /> },

    ];
    const guestRouters = [
        { path: ROUTERS.GUEST.HOME, component: <Home /> },
        { path: ROUTERS.GUEST.ABOUT, component: <About/>},
        { path: ROUTERS.GUEST.SERVICE, component: <Service/>},
        { path: ROUTERS.GUEST.EXPERTS, component: <ExpertUserView/>},
        { path: ROUTERS.GUEST.LOGIN, component: <LoginSignupForm isLogin={true} /> },
        { path: ROUTERS.GUEST.REGISTER, component: <LoginSignupForm isLogin={false} /> },
        { path: ROUTERS.GUEST.REVIEWS, component: <Review/>},
        { path: ROUTERS.GUEST.CONTACT, component: <Contact/>},
        { path: ROUTERS.GUEST.BOOK, component: <BookingView/>},
    ];


    const expertRouters = [
        { path: ROUTERS.EXPERT.HOME, component: <Expert /> },
    ];

    const adminRouters = [
        { path: ROUTERS.ADMIN.HOME, component: <Admin /> },
    ];

    const role = localStorage.getItem('role'); // Assuming role is stored in localStorage

    switch (role) {
        case 'User':
            return userRoutes(userRouters);
        case 'Expert':
            return expertRoutes(expertRouters);
        case 'Admin':
            return adminRoutes(adminRouters);
        default:
            return guestRoutes(guestRouters);
    }
};

export default RouterCustom;
