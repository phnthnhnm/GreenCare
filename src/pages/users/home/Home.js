import { memo } from 'react';

const Home = () => {
  const Intro = `${process.env.PUBLIC_URL}/img/Service3.png`;
  return (
    <>
      <>
        {/* About Start */}
        <div className="container-xxl py-5">
          <div className="container">
            <div className="row g-5">
              <div
                className="col-lg-6 wow fadeInUp"
                data-wow-delay="0.1s"
                style={{ minHeight: 400 }}
              >
                <div className="position-relative h-100">
                  <img
                    className="img-fluid position-absolute w-100 h-100"
                    src={Intro}
                    alt=""
                    style={{ objectFit: "cover" }}
                  />
                </div>
              </div>
              <div className="col-lg-6 wow fadeInUp" data-wow-delay="0.3s">
                <h6 className="section-title bg-white text-start text-primary pe-3">
                  About Us
                </h6>
                <h1 className="mb-4">
                  Welcome to <span className="text-primary">Green Care</span>
                </h1>
                <p className="mb-4">
                  At GreenCare, we are passionate about plants and deeply committed to
                  their care. We believe that every plant deserves the utmost
                  attention and specialized care tailored to its unique needs. Whether
                  you're a busy professional, a plant enthusiast with a large
                  collection, or someone who simply wants to enhance the beauty of
                  your space with thriving greenery, our team of experienced plant
                  care specialists is here to help.
                  <br />
                  <br />
                  Our comprehensive range of services covers every aspect of plant
                  care, from initial consultation and selection to ongoing maintenance
                  and troubleshooting. We offer personalized care plans designed to
                  meet the specific requirements of each plant, taking into
                  consideration factors such as light exposure, watering needs,
                  fertilization, pest control, and seasonal adjustments. With our
                  expertise and attention to detail, your plants will flourish and
                  thrive under our dedicated care.
                </p>
              </div>
            </div>
            {/* About End */}

            {/* Package Start */}
            <div className="container-xxl py-5">
              <div className="container">
                <div className="text-center wow fadeInUp" data-wow-delay="0.1s">
                  <h6 className="section-title bg-white text-center text-primary px-3">
                    Packages
                  </h6>
                  <h1 className="mb-5">Featured Services</h1>
                </div>
                <div className="row g-4 justify-content-center">
                  <div
                    className="col-lg-4 col-md-6 wow fadeInUp"
                    data-wow-delay="0.1s"
                  >
                    <div className="package-item">
                      <div className="overflow-hidden">
                        <img className="img-fluid" src="img/Service1.jpg" alt="" />
                      </div>
                      <div className="d-flex border-bottom">
                        <small className="flex-fill text-center py-2">
                          <i className="fa fa-user text-primary me-2" />
                          Pest and disease control
                        </small>
                      </div>
                      <div className="text-center p-4">
                        <h3 className="mb-0">120.00</h3>
                        <div className="mb-3">
                          <small className="fa fa-star text-primary" />
                          <small className="fa fa-star text-primary" />
                          <small className="fa fa-star text-primary" />
                          <small className="fa fa-star text-primary" />
                          <small className="fa fa-star text-primary" />
                        </div>
                        <p>
                          If your plant is looking sick, a plant care specialist can
                          help you diagnose the problem and recommend treatment.
                        </p>
                        <div className="d-flex justify-content-center mb-2">
                          <a
                            href="#"
                            className="btn btn-sm btn-primary px-3 border-end"
                            style={{ borderRadius: "30px 0 0 30px" }}
                          >
                            Read More
                          </a>
                          <a
                            href="#"
                            className="btn btn-sm btn-primary px-3"
                            style={{ borderRadius: "0 30px 30px 0" }}
                          >
                            Book Now
                          </a>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div
                    className="col-lg-4 col-md-6 wow fadeInUp"
                    data-wow-delay="0.3s"
                  >
                    <div className="package-item">
                      <div className="overflow-hidden">
                        <img className="img-fluid" src="img/Service2.jpg" alt="" />
                      </div>
                      <div className="d-flex border-bottom">
                        <small className="flex-fill text-center py-2">
                          <i className="fa fa-user text-primary me-2" />
                          Shrub and hedge trimming
                        </small>
                      </div>
                      <div className="text-center p-4">
                        <h3 className="mb-0">$110.00</h3>
                        <div className="mb-3">
                          <small className="fa fa-star text-primary" />
                          <small className="fa fa-star text-primary" />
                          <small className="fa fa-star text-primary" />
                          <small className="fa fa-star text-primary" />
                          <small className="fa fa-star text-primary" />
                        </div>
                        <p>
                          {" "}
                          This is a common service to maintain the desired shape and
                          size of your hedges and bushes.
                        </p>
                        <div className="d-flex justify-content-center mb-2">
                          <a
                            href="#"
                            className="btn btn-sm btn-primary px-3 border-end"
                            style={{ borderRadius: "30px 0 0 30px" }}
                          >
                            Read More
                          </a>
                          <a
                            href="#"
                            className="btn btn-sm btn-primary px-3"
                            style={{ borderRadius: "0 30px 30px 0" }}
                          >
                            Book Now
                          </a>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div
                    className="col-lg-4 col-md-6 wow fadeInUp"
                    data-wow-delay="0.5s"
                  >
                    <div className="package-item">
                      <div className="overflow-hidden">
                        <img className="img-fluid" src="img/Service3.png" alt="" />
                      </div>
                      <div className="d-flex border-bottom">
                        <small className="flex-fill text-center py-2">
                          <i className="fa fa-user text-primary me-2" />
                          General houseplant care
                        </small>
                      </div>
                      <div className="text-center p-4">
                        <h3 className="mb-0">$100.00</h3>
                        <div className="mb-3">
                          <small className="fa fa-star text-primary" />
                          <small className="fa fa-star text-primary" />
                          <small className="fa fa-star text-primary" />
                          <small className="fa fa-star text-primary" />
                          <small className="fa fa-star text-primary" />
                        </div>
                        <p>
                          This includes watering, fertilizing, pruning, and repotting
                          your plants to help it thrive and healthy.
                        </p>
                        <div className="d-flex justify-content-center mb-2">
                          <a
                            href="#"
                            className="btn btn-sm btn-primary px-3 border-end"
                            style={{ borderRadius: "30px 0 0 30px" }}
                          >
                            Read More
                          </a>
                          <a
                            href="#"
                            className="btn btn-sm btn-primary px-3"
                            style={{ borderRadius: "0 30px 30px 0" }}
                          >
                            Book Now
                          </a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            {/* Package End */}

            {/* Booking Start */}
            <div className="container-xxl py-5 wow fadeInUp" data-wow-delay="0.1s">
              <div className="container">
                <div className="booking p-5">
                  <div className="row g-5 align-items-center">
                    <div className="col-md-6 text-white">
                      <h6 className="text-white text-uppercase">Booking</h6>
                      <h1 className="text-white mb-4">Online Booking</h1>
                      <p className="mb-4">
                        {" "}
                        Once you've selected your time slot and provided some details,
                        you'll receive a confirmation email with all the appointment
                        information
                      </p>
                      <a className="btn btn-outline-light py-3 px-5 mt-2" href="">
                        Read More
                      </a>
                    </div>
                    <div className="col-md-6">
                      <h1 className="text-white mb-4">Book A Service</h1>
                      <form>
                        <div className="row g-3">
                          <div className="col-md-6">
                            <div className="form-floating">
                              <input
                                type="text"
                                className="form-control bg-transparent"
                                id="name"
                                placeholder="Your Name"
                              />
                              <label htmlFor="name">Your Name</label>
                            </div>
                          </div>
                          <div className="col-md-6">
                            <div className="form-floating">
                              <input
                                type="email"
                                className="form-control bg-transparent"
                                id="email"
                                placeholder="Your Email"
                              />
                              <label htmlFor="email">Your Email</label>
                            </div>
                          </div>
                          <div className="col-md-6">
                            <div
                              className="form-floating date"
                              id="date3"
                              data-target-input="nearest"
                            >
                              <input
                                type="text"
                                className="form-control bg-transparent datetimepicker-input"
                                id="datetime"
                                placeholder="Date & Time"
                                data-target="#date3"
                                data-toggle="datetimepicker"
                              />
                              <label htmlFor="datetime">Date &amp; Time</label>
                            </div>
                          </div>
                          <div className="col-md-6">
                            <div className="form-floating">
                              <select
                                className="form-select bg-transparent"
                                id="select1"
                              >
                                <option value={1}>Pest and disease control</option>
                                <option value={2}>Shrub and hedge trimming</option>
                                <option value={3}>General houseplant care</option>
                              </select>
                              <label htmlFor="select1">Service</label>
                            </div>
                          </div>
                          <div className="col-12">
                            <div className="form-floating">
                              <textarea
                                className="form-control bg-transparent"
                                placeholder="Special Request"
                                id="message"
                                style={{ height: 100 }}
                                defaultValue={""}
                              />
                              <label htmlFor="message">Special Request</label>
                            </div>
                          </div>
                          <div className="col-12">
                            <button
                              className="btn btn-outline-light w-100 py-3"
                              type="submit"
                            >
                              Book Now
                            </button>
                          </div>
                        </div>
                      </form>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            {/* Booking End */}

            {/* Process Start */}
            <div className="container-xxl py-5">
              <div className="container">
                <div className="text-center pb-4 wow fadeInUp" data-wow-delay="0.1s">
                  <h6 className="section-title bg-white text-center text-primary px-3">
                    Process
                  </h6>
                  <h1 className="mb-5">3 Easy Steps</h1>
                </div>
                <div className="row gy-5 gx-4 justify-content-center">
                  <div
                    className="col-lg-4 col-sm-6 text-center pt-4 wow fadeInUp"
                    data-wow-delay="0.1s"
                  >
                    <div className="position-relative border border-primary pt-5 pb-4 px-4">
                      <div
                        className="d-inline-flex align-items-center justify-content-center bg-primary rounded-circle position-absolute top-0 start-50 translate-middle shadow"
                        style={{ width: 100, height: 100 }}
                      >
                        <i className="fa fa-globe fa-3x text-white" />
                      </div>
                      <h5 className="mt-4">Choose A Service</h5>
                      <hr className="w-25 mx-auto bg-primary mb-1" />
                      <hr className="w-50 mx-auto bg-primary mt-0" />
                      <p className="mb-0">
                        We offer a variety of plant wellness consultations, from basic
                        health checks to in-depth troubleshooting for struggling
                        plants
                      </p>
                    </div>
                  </div>
                  <div
                    className="col-lg-4 col-sm-6 text-center pt-4 wow fadeInUp"
                    data-wow-delay="0.3s"
                  >
                    <div className="position-relative border border-primary pt-5 pb-4 px-4">
                      <div
                        className="d-inline-flex align-items-center justify-content-center bg-primary rounded-circle position-absolute top-0 start-50 translate-middle shadow"
                        style={{ width: 100, height: 100 }}
                      >
                        <i className="fa fa-dollar-sign fa-3x text-white" />
                      </div>
                      <h5 className="mt-4">Pay Online</h5>
                      <hr className="w-25 mx-auto bg-primary mb-1" />
                      <hr className="w-50 mx-auto bg-primary mt-0" />
                      <p className="mb-0">
                        Give your plants the care they deserve! Book your online plant
                        wellness consultation today and watch your indoor oasis
                        flourish.
                      </p>
                    </div>
                  </div>
                  <div
                    className="col-lg-4 col-sm-6 text-center pt-4 wow fadeInUp"
                    data-wow-delay="0.5s"
                  >
                    <div className="position-relative border border-primary pt-5 pb-4 px-4">
                      <div
                        className="d-inline-flex align-items-center justify-content-center bg-primary rounded-circle position-absolute top-0 start-50 translate-middle shadow"
                        style={{ width: 100, height: 100 }}
                      >
                        <i className="fa fa-plane fa-3x text-white" />
                      </div>
                      <h5 className="mt-4">Relax and let us handle </h5>
                      <hr className="w-25 mx-auto bg-primary mb-1" />
                      <hr className="w-50 mx-auto bg-primary mt-0" />
                      <p className="mb-0">
                        Our experienced plant care specialists will visit your home or
                        office and assess the overall health of your plants.
                      </p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            {/* Process Start */}

            {/* Team Start */}
            <div className="container-xxl py-5">
              <div className="container">
                <div className="text-center wow fadeInUp" data-wow-delay="0.1s">
                  <h6 className="section-title bg-white text-center text-primary px-3">
                    Plant Care Guide
                  </h6>
                  <h1 className="mb-5">Meet Our Guide</h1>
                </div>
                <div className="row g-4">
                  <div
                    className="col-lg-3 col-md-6 wow fadeInUp"
                    data-wow-delay="0.1s"
                  >
                    <div className="team-item">
                      <div className="overflow-hidden">
                        <img className="img-fluid" src="img/team-1.jpg" alt="" />
                      </div>
                      <div
                        className="position-relative d-flex justify-content-center"
                        style={{ marginTop: "-19px" }}
                      >
                        <a className="btn btn-square mx-1" href="">
                          <i className="fab fa-facebook-f" />
                        </a>
                        <a className="btn btn-square mx-1" href="">
                          <i className="fab fa-twitter" />
                        </a>
                        <a className="btn btn-square mx-1" href="">
                          <i className="fab fa-instagram" />
                        </a>
                      </div>
                      <div className="text-center p-4">
                        <h5 className="mb-0">Full Name</h5>
                        <small>Designation</small>
                      </div>
                    </div>
                  </div>
                  <div
                    className="col-lg-3 col-md-6 wow fadeInUp"
                    data-wow-delay="0.3s"
                  >
                    <div className="team-item">
                      <div className="overflow-hidden">
                        <img className="img-fluid" src="img/team-2.jpg" alt="" />
                      </div>
                      <div
                        className="position-relative d-flex justify-content-center"
                        style={{ marginTop: "-19px" }}
                      >
                        <a className="btn btn-square mx-1" href="">
                          <i className="fab fa-facebook-f" />
                        </a>
                        <a className="btn btn-square mx-1" href="">
                          <i className="fab fa-twitter" />
                        </a>
                        <a className="btn btn-square mx-1" href="">
                          <i className="fab fa-instagram" />
                        </a>
                      </div>
                      <div className="text-center p-4">
                        <h5 className="mb-0">Full Name</h5>
                        <small>Designation</small>
                      </div>
                    </div>
                  </div>
                  <div
                    className="col-lg-3 col-md-6 wow fadeInUp"
                    data-wow-delay="0.5s"
                  >
                    <div className="team-item">
                      <div className="overflow-hidden">
                        <img className="img-fluid" src="img/team-3.jpg" alt="" />
                      </div>
                      <div
                        className="position-relative d-flex justify-content-center"
                        style={{ marginTop: "-19px" }}
                      >
                        <a className="btn btn-square mx-1" href="">
                          <i className="fab fa-facebook-f" />
                        </a>
                        <a className="btn btn-square mx-1" href="">
                          <i className="fab fa-twitter" />
                        </a>
                        <a className="btn btn-square mx-1" href="">
                          <i className="fab fa-instagram" />
                        </a>
                      </div>
                      <div className="text-center p-4">
                        <h5 className="mb-0">Full Name</h5>
                        <small>Designation</small>
                      </div>
                    </div>
                  </div>
                  <div
                    className="col-lg-3 col-md-6 wow fadeInUp"
                    data-wow-delay="0.7s"
                  >
                    <div className="team-item">
                      <div className="overflow-hidden">
                        <img className="img-fluid" src="img/team-4.jpg" alt="" />
                      </div>
                      <div
                        className="position-relative d-flex justify-content-center"
                        style={{ marginTop: "-19px" }}
                      >
                        <a className="btn btn-square mx-1" href="">
                          <i className="fab fa-facebook-f" />
                        </a>
                        <a className="btn btn-square mx-1" href="">
                          <i className="fab fa-twitter" />
                        </a>
                        <a className="btn btn-square mx-1" href="">
                          <i className="fab fa-instagram" />
                        </a>
                      </div>
                      <div className="text-center p-4">
                        <h5 className="mb-0">Full Name</h5>
                        <small>Designation</small>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            {/* Team End */}


            {/* Testimonial Start */}
            <div className="container-xxl py-5 wow fadeInUp" data-wow-delay="0.1s">
              <div className="container">
                <div className="text-center">
                  <h6 className="section-title bg-white text-center text-primary px-3">
                    Testimonial
                  </h6>
                  <h1 className="mb-5">Our Clients Say!!!</h1>
                </div>
                <div className="owl-carousel testimonial-carousel position-relative">
                  <div className="testimonial-item bg-white text-center border p-4">
                    <img
                      className="bg-white rounded-circle shadow p-1 mx-auto mb-3"
                      src="img/testimonial-1.jpg"
                      style={{ width: 80, height: 80 }}
                    />
                    <h5 className="mb-0">John Doe</h5>
                    <p>New York, USA</p>
                    <p className="mb-0">
                      No matter what I did, my fiddle leaf fig just wouldn't thrive.
                      Then I found GreenCare and their houseplant care service. Their
                      experts diagnosed the problem and gave me a personalized care
                      plan. Now, my fig is flourishing, and I'm even expanding my
                      plant collection thanks them! Highly recommend!"
                    </p>
                  </div>
                  <div className="testimonial-item bg-white text-center border p-4">
                    <img
                      className="bg-white rounded-circle shadow p-1 mx-auto mb-3"
                      src="img/testimonial-2.jpg"
                      style={{ width: 80, height: 80 }}
                    />
                    <h5 className="mb-0">John Doe</h5>
                    <p>New York, USA</p>
                    <p className="mt-2 mb-0">
                      I was at my wit's end with those pesky aphids ruining my rose
                      bushes! Thankfully, I discovered GreenCare's service. They
                      identified the exact pest, treated my garden safely and
                      effectively, and even offered tips to prevent future
                      infestations. My roses are back to their beautiful, healthy
                      selves, and I couldn't be happier.
                    </p>
                  </div>
                  <div className="testimonial-item bg-white text-center border p-4">
                    <img
                      className="bg-white rounded-circle shadow p-1 mx-auto mb-3"
                      src="img/testimonial-3.jpg"
                      style={{ width: 80, height: 80 }}
                    />
                    <h5 className="mb-0">John Doe</h5>
                    <p>New York, USA</p>
                    <p className="mt-2 mb-0">
                      My overgrown hedges were an eyesore. I knew I needed
                      professional help, so I contacted GreenCare. Their team was
                      punctual, efficient, and did an amazing job! My hedges now look
                      neat and tidy, perfectly framing my house. They even cleaned up
                      afterwards, leaving my yard spotless. Outstanding service!
                    </p>
                  </div>
                  <div className="testimonial-item bg-white text-center border p-4">
                    <img
                      className="bg-white rounded-circle shadow p-1 mx-auto mb-3"
                      src="img/testimonial-4.jpg"
                      style={{ width: 80, height: 80 }}
                    />
                    <h5 className="mb-0">John Doe</h5>
                    <p>New York, USA</p>
                    <p className="mt-2 mb-0">
                      I love having a vibrant garden, but keeping up with everything
                      can be overwhelming. GreenCare's general plant care service has
                      been a lifesaver. Their technicians are knowledgeable and
                      passionate, taking care of everything from watering and
                      fertilizing to pruning and pest monitoring
                    </p>
                  </div>
                </div>
              </div>
            </div>
            {/* Testimonial End */}
          </div>
        </div>
      </>

    </>
  )
}

export default memo(Home);