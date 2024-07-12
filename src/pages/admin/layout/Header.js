import { memo } from 'react';
import { Link } from 'react-router-dom';
import { ROUTERS } from '../../../utils/router';


const Header = () => {
    return (
        <>
            {/* Topbar Start */}
            <div className="container-fluid bg-dark px-5 d-none d-lg-block">
                <div className="row gx-0">
                    <div className="col-lg-8 text-center text-lg-start mb-2 mb-lg-0">
                        <div
                            className="d-inline-flex align-items-center"
                            style={{ height: 45 }}
                        >
                            <small className="me-3 text-light">
                                <i className="fa fa-map-marker-alt me-2" />
                                123 Street, Ho Chi Minh, VietNam
                            </small>
                            <small className="me-3 text-light">
                                <i className="fa fa-phone-alt me-2" />
                                +012 345 6789
                            </small>
                            <small className="text-light">
                                <i className="fa fa-envelope-open me-2" />
                                info@example.com
                            </small>
                        </div>
                    </div>
                    <div className="col-lg-4 text-center text-lg-end">
                        <div
                            className="d-inline-flex align-items-center"
                            style={{ height: 45 }}
                        >
                            <a
                                className="btn btn-sm btn-outline-light btn-sm-square rounded-circle me-2"
                                href=""
                            >
                                <i className="fab fa-twitter fw-normal" />
                            </a>
                            <a
                                className="btn btn-sm btn-outline-light btn-sm-square rounded-circle me-2"
                                href=""
                            >
                                <i className="fab fa-facebook-f fw-normal" />
                            </a>
                            <a
                                className="btn btn-sm btn-outline-light btn-sm-square rounded-circle me-2"
                                href=""
                            >
                                <i className="fab fa-linkedin-in fw-normal" />
                            </a>
                            <a
                                className="btn btn-sm btn-outline-light btn-sm-square rounded-circle me-2"
                                href=""
                            >
                                <i className="fab fa-instagram fw-normal" />
                            </a>
                            <a
                                className="btn btn-sm btn-outline-light btn-sm-square rounded-circle"
                                href=""
                            >
                                <i className="fab fa-youtube fw-normal" />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            {/* Topbar End */}
            
            {/* Navbar & Hero Start */}
            <div className="container-fluid position-relative p-0">
                <nav className="navbar navbar-expand-lg navbar-light px-4 px-lg-5 py-3 py-lg-0">
                    <a href="" className="navbar-brand p-0">
                        <h1 className="text-primary m-0">
                            <i className="fa fa-map-marker-alt me-3" />
                            <Link to={ROUTERS.USER.HOME}>Green Care</Link>
                        </h1>
                        {/* <img src="img/logo.png" alt="Logo"> */}
                    </a>
                    <button
                        className="navbar-toggler"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#navbarCollapse"
                    >
                        <span className="fa fa-bars" />
                    </button>
                    <div className="collapse navbar-collapse" id="navbarCollapse">
                        <div className="navbar-nav ms-auto py-0">
                            <Link to={ROUTERS.USER.HOME} className="nav-item nav-link">
                                Home
                            </Link>
                            <Link to={ROUTERS.USER.ABOUT} className="nav-item nav-link">
                                About
                            </Link>
                            <Link to={ROUTERS.USER.SERVICE} className="nav-item nav-link">
                                Services
                            </Link>
                            <div className="nav-item dropdown">
                                <a
                                    href="#"
                                    className="nav-link dropdown-toggle"
                                    data-bs-toggle="dropdown"
                                >
                                    Pages
                                </a>
                                <div className="dropdown-menu m-0">
                                    <Link to={ROUTERS.USER.BOOK} className="dropdown-item">
                                        Booking
                                    </Link>
                                    <Link to={ROUTERS.USER.EXPERTS} className="dropdown-item">
                                        Experts
                                    </Link>
                                    <Link to={ROUTERS.USER.REVIEWS} className="dropdown-item">
                                        Reviews
                                    </Link>
                                </div>
                            </div>
                            <Link to={ROUTERS.USER.CONTACT} className="nav-item nav-link">
                                Contact
                            </Link>

                            <div className="nav-item dropdown">
                                <a
                                    href="#"
                                    className="nav-link dropdown-toggle"
                                    data-bs-toggle="dropdown"
                                >
                                    Account
                                </a>
                                <div className="dropdown-menu m-0">
                                    <Link to={ROUTERS.USER.LOGIN} className="dropdown-item">
                                        Login
                                    </Link>
                                    <Link to={ROUTERS.USER.LOGOUT} className="dropdown-item">
                                        Logout
                                    </Link>
                                </div>
                            </div>
                        </div>
                    </div>
                </nav>
            </div>
            {/* NavbarEnd */}

            <div className="container-fluid bg-primary py-5 mb-5 hero-header" >
                <div className="container py-5">
                    <div className="row justify-content-center py-5">
                        <div className="col-lg-10 pt-lg-5 mt-lg-5 text-center">
                            <h1 className="display-3 text-white mb-3 animated slideInDown">
                                Your plants' best friend
                            </h1>
                            <p className="fs-4 text-white mb-4 animated slideInDown">
                                Grow vibrant, healthy plants that add beauty and life to your
                                space
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </>

    )
}

export default memo(Header);