import { Link } from "react-router-dom";

function ArticleCard({ article }) {
  return (
    <div className="card shadow-sm mb-3">
      <div className="card-body">
        <h5 className="card-title">{article.title}</h5>
        <p className="card-text text-muted">{article.summary}</p>
        <Link to={`/article/${article.id}`} className="btn btn-primary">
          Read More
        </Link>
      </div>
    </div>
  );
}

export default ArticleCard;