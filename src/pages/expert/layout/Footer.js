import { memo } from 'react';

const Footer = () => {
  const Service1 = `${process.env.PUBLIC_URL}/img/Service1.jpg`;
  const Service2 = `${process.env.PUBLIC_URL}/img/Service2.jpg`;
  const Service3 = `${process.env.PUBLIC_URL}/img/Service3.png`;


  return (
    <>
      <div
        className="container-fluid bg-dark text-light footer pt-5 mt-5 wow fadeIn"
        data-wow-delay="0.1s"
      >
        <div className="container py-5">
          <div className="row g-5">
            <div className="col-lg-3 col-md-6">
              <h4 className="text-white mb-3">Company</h4>
              <a className="btn btn-link" href="">
                About Us
              </a>
              <a className="btn btn-link" href="">
                Contact Us
              </a>
              <a className="btn btn-link" href="">
                Privacy Policy
              </a>
              <a className="btn btn-link" href="">
                Terms &amp; Condition
              </a>
              <a className="btn btn-link" href="">
                FAQs &amp; Help
              </a>
            </div>
            <div className="col-lg-3 col-md-6">
              <h4 className="text-white mb-3">Contact</h4>
              <p className="mb-2">
                <i className="fa fa-map-marker-alt me-3" />
                123 Street, Ho Chi Minh, VietNam
              </p>
              <p className="mb-2">
                <i className="fa fa-phone-alt me-3" />
                +012 345 67890
              </p>
              <p className="mb-2">
                <i className="fa fa-envelope me-3" />
                info@example.com
              </p>
              <div className="d-flex pt-2">
                <a className="btn btn-outline-light btn-social" href="">
                  <i className="fab fa-twitter" />
                </a>
                <a className="btn btn-outline-light btn-social" href="">
                  <i className="fab fa-facebook-f" />
                </a>
                <a className="btn btn-outline-light btn-social" href="">
                  <i className="fab fa-youtube" />
                </a>
                <a className="btn btn-outline-light btn-social" href="">
                  <i className="fab fa-linkedin-in" />
                </a>
              </div>
            </div>
            <div className="col-lg-3 col-md-6">
              <h4 className="text-white mb-3">Gallery</h4>
              <div className="row g-2 pt-2">
                <div className="col-4">
                  <img
                    className="img-fluid bg-light p-1"
                    src={Service1}
                    alt=""
                  />
                </div>
                <div className="col-4">
                  <img
                    className="img-fluid bg-light p-1"
                    src={Service2}
                    alt=""
                  />
                </div>
                <div className="col-4">
                  <img
                    className="img-fluid bg-light p-1"
                    src={Service3}
                    alt=""
                  />
                </div>
              </div>
            </div>
            <div className="col-lg-3 col-md-6">
              <h4 className="text-white mb-3">Order our service now !</h4>
              <div className="position-relative mx-auto" style={{ maxWidth: 400 }}>
                <input
                  className="form-control border-primary w-100 py-3 ps-4 pe-5"
                  type="text"
                  placeholder="Your email"
                />
                <button
                  type="button"
                  className="btn btn-primary py-2 position-absolute top-0 end-0 mt-2 me-2"
                >
                  SignUp
                </button>
              </div>
            </div>
          </div>
        </div>
        <div className="container">
          <div className="copyright">
            <div className="row">
              <div className="col-md-6 text-center text-md-start mb-3 mb-md-0">
                ©{" "}
                <a className="border-bottom" href="#">
                  GreenCare
                </a>
                , All Right Reserved.
                {/*/*** This template is free as long as you keep the footer author’s credit link/attribution link/backlink. If you'd like to use the template without the footer author’s credit link/attribution link/backlink, you can purchase the Credit Removal License from "https://htmlcodex.com/credit-removal". Thank you for your support. *** /*/}
                Designed By{" "}
                <a className="border-bottom" href="https://htmlcodex.com">
                  HTML Codex
                </a>
              </div>
              <div className="col-md-6 text-center text-md-end">
                <div className="footer-menu">
                  <a href="">Home</a>
                  <a href="">Cookies</a>
                  <a href="">Help</a>
                  <a href="">FQAs</a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      {/* Footer End */}
    </>

  )
}

export default memo(Footer);