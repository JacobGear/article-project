import { Link } from "react-router-dom";

function Navbar() {
  return (
    <nav className="navbar navbar-dark bg-dark p-3">
      <div className="container">
        <Link to="/" className="navbar-brand">My Articles</Link>
      </div>
    </nav>
  );
}

export default Navbar;