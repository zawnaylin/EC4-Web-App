import { Link } from 'react-router-dom';
import "./Navbar.css";

const Navbar = ({ name, setName }) => {
  const logout = () => {
    setName("");
  }

  return (
    <nav className="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
      <div className="container-fluid">
        <Link className="navbar-brand" to="/">4th Batch Electronics</Link>
        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarCollapse">
          <ul className="navbar-nav ms-auto mb-2 mb-md-0">
            <li className="nav-item">
              <Link className="nav-link active" aria-current="page" to="/">Home</Link>
            </li>
            <li className="nav-item">
              {name !== "" ?
                <Link className="nav-link active" to="/login" onClick={logout}>Hello {name}</Link> :
                <Link className="nav-link active" to="/login">Login</Link>
              }
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
}

export default Navbar;