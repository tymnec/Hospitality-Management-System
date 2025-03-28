import React from "react";
import "./Review.css";
import "bootstrap/dist/css/bootstrap.min.css";

const Review = () => {
  return (
    <div className="container my-5">
      <h1 className="mb-4">Reviews</h1>
      <div className="list-group">
        <div className="list-group-item">
          <p className="mb-1">
            Great hospital! The staff is very friendly and helpful.
          </p>
          <small className="text-muted">- John Doe</small>
        </div>
        <div className="list-group-item">
          <p className="mb-1">
            I had a great experience at this hospital. The doctors and nurses
            were very professional and caring.
          </p>
          <small className="text-muted">- Jane Doe</small>
        </div>
        <div className="list-group-item">
          <p className="mb-1">
            The hospital was clean and comfortable. The food was also very good.
          </p>
          <small className="text-muted">- Bob Smith</small>
        </div>
      </div>
    </div>
  );
};

export default Review;
