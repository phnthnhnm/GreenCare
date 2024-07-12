import { memo } from 'react';


const Introduction = `${process.env.PUBLIC_URL}/img/Introduction.png`;
const About = () => {
  return (
    <>
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
                  src={Introduction}
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
                their care. We believe that every plant deserves the utmost attention
                and specialized care tailored to its unique needs. Whether you're a
                busy professional, a plant enthusiast with a large collection, or
                someone who simply wants to enhance the beauty of your space with
                thriving greenery, our team of experienced plant care specialists is
                here to help.
                <br />
                <br />
                Our comprehensive range of services covers every aspect of plant care,
                from initial consultation and selection to ongoing maintenance and
                troubleshooting. We offer personalized care plans designed to meet the
                specific requirements of each plant, taking into consideration factors
                such as light exposure, watering needs, fertilization, pest control,
                and seasonal adjustments. With our expertise and attention to detail,
                your plants will flourish and thrive under our dedicated care.
              </p>
            </div>
          </div>
        </div>
      </div>

    </>
  )
}

export default memo(About);