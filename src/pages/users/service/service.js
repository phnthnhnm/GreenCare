import { memo, useEffect, useState } from 'react';
import { getAllServices } from '../../../api/services';
import { ROUTERS } from '../../../utils/router';
import { Link } from 'react-router-dom';

const Services = () => {
    const [services, setServices] = useState([]);

    useEffect(() => {
        const fetchServices = async () => {
            
            const data = await getAllServices();
            setServices(data);
        };
        fetchServices();
    }, []);


    return (
        <div className="container-xxl py-5">
            <div className="container">
                <div className="text-center wow fadeInUp" data-wow-delay="0.1s">
                    <h6 className="section-title bg-white text-center text-primary px-3">
                        Packages
                    </h6>
                    <h1 className="mb-5">Awesome Services</h1>
                </div>

                <div className="row g-4 justify-content-center">
                    {services.map(service => (
                        <div className="col-lg-4 col-md-6 wow fadeInUp" data-wow-delay="0.1s" key={service.id}>
                            <div className="package-item">
                                <div className="d-flex border-bottom">
                                    <small className="flex-fill text-center py-2">
                                        <i className="fa fa-user text-primary me-2" />
                                        {service.name}
                                    </small>
                                </div>
                                <div className="text-center p-4">
                                    <h3 className="mb-0">${service.price}</h3>
                                    <div className="mb-3">
                                    <p>Duration: {service.duration} minutes</p>
                                    </div>
                                    <p>{service.description}</p>
                                    <div className="d-flex justify-content-center mb-2">
                                    <Link to = {ROUTERS.GUEST.BOOK} state ={{id: service.id}}
                                        className="btn btn-sm btn-primary px-3"
                                        style={{ borderRadius: "30px 30px 30px 30px" }}
                                    >
                                        Book Now
                                    </Link>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
            </div>
        </div>

    );
}

export default memo(Services);