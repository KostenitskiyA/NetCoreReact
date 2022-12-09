import React, { useState } from "react";

const Profile = () => {
  const [isCropperModalOpen, setIsCropperModalOpen] = useState(false);

  const toggleCropperModal = () => {
    setIsCropperModalOpen(!isCropperModalOpen);
  }

  return (
    <div className="profile">
      <div className="container">
        <div className="col">            
          <div className="avatar" onClick={() => {toggleCropperModal}}>{avatarImg}</div>
        </div>
      </div>

      <div className="container">
        <div className="col">
          <div className="input-form">
            <label className="input-label">Id</label>
            <input type="text" readOnly value={id}></input>
          </div>
          <div className="input-form">
            <label className="input-label">Name</label>
            <input type="text" readOnly value={name}></input>
          </div>
          {/* <div className="input-form">
            <Link to="settings">
              <button>Change password</button>
            </Link>
          </div> */}
        </div>
      </div>

      <Modal
        isModalOpen={isCropperModalOpen}
        onCloseModal={toggleCropperModal}
      >
        {/* <AvatarCropper /> */}
      </Modal>
    </div>
  );
}

export default Profile;