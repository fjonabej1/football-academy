export default function Header() {
  return (
    <header className="h-16 bg-white shadow flex items-center px-6 justify-between">
      <h1 className="text-lg font-semibold">Dashboard</h1>

      <div>
        <button className="text-sm bg-gray-200 px-3 py-1 rounded">
          Logout
        </button>
      </div>
    </header>
  )
}