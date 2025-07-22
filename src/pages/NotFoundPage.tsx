import { Link } from 'react-router-dom'
import { Home, ArrowLeft, Search } from 'lucide-react'
import { motion } from 'framer-motion'

export function NotFoundPage() {
  return (
    <div className="min-h-screen bg-secondary-50 flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
      <motion.div
        initial={{ opacity: 0, y: 20 }}
        animate={{ opacity: 1, y: 0 }}
        className="max-w-md w-full text-center"
      >
        {/* 404 Illustration */}
        <div className="mb-8">
          <div className="text-9xl font-bold text-primary-600 mb-4">404</div>
          <div className="w-32 h-32 bg-primary-100 rounded-full flex items-center justify-center mx-auto mb-6">
            <Search className="w-16 h-16 text-primary-600" />
          </div>
        </div>

        {/* Content */}
        <div className="space-y-6">
          <h1 className="text-3xl font-bold text-secondary-900">
            Sahifa topilmadi
          </h1>
          <p className="text-lg text-secondary-600 leading-relaxed">
            Kechirasiz, siz qidirayotgan sahifa mavjud emas yoki ko'chirilgan bo'lishi mumkin.
          </p>
          
          {/* Actions */}
          <div className="flex flex-col sm:flex-row gap-4 justify-center">
            <Link
              to="/"
              className="btn-primary inline-flex items-center justify-center space-x-2"
            >
              <Home className="w-4 h-4" />
              <span>Bosh sahifaga qaytish</span>
            </Link>
            <button
              onClick={() => window.history.back()}
              className="btn-outline inline-flex items-center justify-center space-x-2"
            >
              <ArrowLeft className="w-4 h-4" />
              <span>Orqaga qaytish</span>
            </button>
          </div>
        </div>

        {/* Suggestions */}
        <div className="mt-12 p-6 bg-white rounded-xl shadow-sm">
          <h3 className="text-lg font-semibold text-secondary-900 mb-4">
            Quyidagilarni sinab ko'ring:
          </h3>
          <div className="space-y-3 text-left">
            <Link
              to="/courses"
              className="block p-3 rounded-lg hover:bg-secondary-50 transition-colors"
            >
              <div className="font-medium text-secondary-900">Kurslar</div>
              <div className="text-sm text-secondary-600">Barcha mavjud kurslarni ko'ring</div>
            </Link>
            <Link
              to="/instructors"
              className="block p-3 rounded-lg hover:bg-secondary-50 transition-colors"
            >
              <div className="font-medium text-secondary-900">O'qituvchilar</div>
              <div className="text-sm text-secondary-600">Professional o'qituvchilar bilan tanishing</div>
            </Link>
            <Link
              to="/students"
              className="block p-3 rounded-lg hover:bg-secondary-50 transition-colors"
            >
              <div className="font-medium text-secondary-900">Talabalar</div>
              <div className="text-sm text-secondary-600">Boshqa talabalar bilan bog'laning</div>
            </Link>
          </div>
        </div>
      </motion.div>
    </div>
  )
}