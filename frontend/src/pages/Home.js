import { Link } from "react-router-dom";
import { fetchArticles } from "../data/articles";
import { useEffect, useState } from "react";

function Home() {
  const [articles, setArticles] = useState([]);

  useEffect(() => {
    fetchArticles().then(setArticles);
  }, []);

  return (
    <div className="container mt-4">
      <h1 className="mb-4">Articles</h1>
      <div className="d-flex flex-column gap-3">
        {articles.map((article) => (
          <div key={article.id} className="card p-3">
            <h2 className="h5">{article.title}</h2>
            <Link to={`/article/${article.id}`} className="btn btn-primary mt-2">
              Read More
            </Link>
          </div>
        ))}
      </div>
    </div>
  );
}

export default Home;