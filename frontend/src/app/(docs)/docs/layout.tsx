import "./style.css";

export default function DocsLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return <div className="docs">{children}</div>;
}
