import { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import { Search, BookOpen, Award, Calendar, Users } from 'lucide-react'
import { motion } from 'framer-motion'
import type { Student } from '../types'

export function StudentsPage() {
  const [students, setStudents] = useState<Student[]>([])
  const [loading, setLoading] = useState(true)
  const [searchTerm, setSearchTerm] = useState('')

  // Mock data - replace with API call
  useEffect(() => {
    const mockStudents: Student[] = [
      {
        id: '1',
        email: 'aziza@example.com',
        firstName: 'Aziza',
        lastName: 'Normatova',
        role: 'student',
        avatar: 'https://images.pexels.com/photos/774909/pexels-photo-774909.jpeg?auto=compress&cs=tinysrgb&w=300',
        enrolledCourses: [],
        completedCourses: [],
        progress: [],
        createdAt: '2024-01-15',
        updatedAt: '2024-01-15',
      },
      {
        id: '2',
        email: 'bobur@example.com',
        firstName: 'Bobur',
        lastName: 'Ismoilov',
        role: 'student',
        avatar: 'https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg?auto=compress&cs=tinysrgb&w=300',
        enrolledCourses: [],
        completedCourses: [],
        progress: [],
        createdAt: '2024-01-10',
        updatedAt: '2024-01-10',
      },
      {
        id: '3',
        email: 'nilufar@example.com',
        firstName: 'Nilufar',
        lastName: 'Karimova',
        role: 'student',
        avatar: 'https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&w=300',
        enrolledCourses: [],
        completedCourses: [],
        progress: [],
        createdAt: '2024-01-08',
        updatedAt: '2024-01-08',
      },
      {
        id: '4',
        email: 'jasur@example.com',
        firstName: 'Jasur',
        lastName: 'Rahmonov',
        role: 'student',
        avatar: 'https://images.pexels.com/photos/1681010/pexels-photo-1681010.jpeg?auto=compress&cs=tinysrgb&w=300',
        enrolledCourses: [],
        completedCourses: [],
        progress: [],
        createdAt: '2024-01-05',
        updatedAt: '2024-01-05',
      },
      {
        id: '5',
        email: 'madina@example.com',
        firstName: 'Madina',
        lastName: 'Tosheva',
        role: 'student',
        avatar: 'https://images.pexels.com/photos/1239291/pexels-photo-1239291.jpeg?auto=compress&cs=tinysrgb&w=300',
        enrolledCourses: [],
        completedCourses: [],
        progress: [],
        createdAt: '2024-01-03',
        updatedAt: '2024-01-03',
      },
      {
        id: '6',
        email: 'otabek@example.com',
        firstName: 'Otabek',
        lastName: 'Umarov',
        role: 'student',
        avatar: 'https://images.pexels.com/photos/1222271/pexels-photo-1222271.jpeg?auto=compress&cs=tinysrgb&w=300',
        enrolledCourses: [],
        completedCourses: [],
        progress: [],
        createdAt: '2024-01-01',
        updatedAt: '2024-01-01',
      },
    ]

    setTimeout(() => {
      setStudents(mockStudents)
      setLoading(false)
    }, 1000)
  }, [])

  const filteredStudents = students.filter(student =>
    `${student.firstName} ${student.lastName}`.toLowerCase().includes(searchTerm.toLowerCase()) ||
    student.email.toLowerCase().includes(searchTerm.toLowerCase())
  )

  if (loading) {
    return (
      <div className="min-h-screen bg-secondary-50 py-12">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="animate-pulse">
            <div className="h-8 bg-secondary-200 rounded w-1/4 mb-8"></div>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-6">
              {[...Array(8)].map((_, i) => (
                <div key={i} className="bg-white rounded-xl p-6">
                  <div className="w-16 h-16 bg-secondary-200 rounded-full mx-auto mb-4"></div>
                  <div className="h-4 bg-secondary-200 rounded mb-2"></div>
                  <div className="h-4 bg-secondary-200 rounded w-3/4 mx-auto"></div>
                </div>
              ))}
            </div>
          </div>
        </div>
      </div>
    )
  }

  return (
    <div className="min-h-screen bg-secondary-50 py-12">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        {/* Header */}
        <div className="text-center mb-12">
          <h1 className="text-3xl lg:text-4xl font-bold text-secondary-900 mb-4">
            Bizning talabalar
          </h1>
          <p className="text-xl text-secondary-600 max-w-2xl mx-auto">
            EduFinder platformasida o'qiyotgan va muvaffaqiyat qozonayotgan talabalar
          </p>
        </div>

        {/* Search */}
        <div className="max-w-md mx-auto mb-12">
          <div className="relative">
            <Search className="absolute left-3 top-1/2 transform -translate-y-1/2 w-5 h-5 text-secondary-400" />
            <input
              type="text"
              placeholder="Talaba qidirish..."
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
              className="w-full pl-10 pr-4 py-3 border border-secondary-300 rounded-lg focus:ring-2 focus:ring-primary-500 focus:border-transparent text-lg"
            />
          </div>
        </div>

        {/* Stats */}
        <div className="grid grid-cols-1 md:grid-cols-4 gap-6 mb-12">
          <div className="bg-white rounded-xl p-6 text-center shadow-sm">
            <div className="w-12 h-12 bg-primary-100 rounded-full flex items-center justify-center mx-auto mb-4">
              <Users className="w-6 h-6 text-primary-600" />
            </div>
            <div className="text-2xl font-bold text-secondary-900 mb-1">
              {students.length}
            </div>
            <div className="text-secondary-600 text-sm">
              Jami talabalar
            </div>
          </div>
          
          <div className="bg-white rounded-xl p-6 text-center shadow-sm">
            <div className="w-12 h-12 bg-success-100 rounded-full flex items-center justify-center mx-auto mb-4">
              <BookOpen className="w-6 h-6 text-success-600" />
            </div>
            <div className="text-2xl font-bold text-secondary-900 mb-1">
              2,450
            </div>
            <div className="text-secondary-600 text-sm">
              Tugatilgan kurslar
            </div>
          </div>
          
          <div className="bg-white rounded-xl p-6 text-center shadow-sm">
            <div className="w-12 h-12 bg-warning-100 rounded-full flex items-center justify-center mx-auto mb-4">
              <Award className="w-6 h-6 text-warning-600" />
            </div>
            <div className="text-2xl font-bold text-secondary-900 mb-1">
              1,890
            </div>
            <div className="text-secondary-600 text-sm">
              Sertifikatlar
            </div>
          </div>
          
          <div className="bg-white rounded-xl p-6 text-center shadow-sm">
            <div className="w-12 h-12 bg-error-100 rounded-full flex items-center justify-center mx-auto mb-4">
              <Calendar className="w-6 h-6 text-error-600" />
            </div>
            <div className="text-2xl font-bold text-secondary-900 mb-1">
              95%
            </div>
            <div className="text-secondary-600 text-sm">
              Faollik darajasi
            </div>
          </div>
        </div>

        {/* Results Count */}
        <div className="mb-8">
          <p className="text-secondary-600 text-center">
            {filteredStudents.length} ta talaba topildi
          </p>
        </div>

        {/* Students Grid */}
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-6">
          {filteredStudents.map((student, index) => (
            <motion.div
              key={student.id}
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.6, delay: index * 0.1 }}
              className="card-hover p-6 text-center group"
            >
              <div className="relative mb-4">
                <img
                  src={student.avatar}
                  alt={`${student.firstName} ${student.lastName}`}
                  className="w-16 h-16 rounded-full object-cover mx-auto group-hover:scale-105 transition-transform duration-300"
                />
                <div className="absolute -bottom-1 -right-1 w-6 h-6 bg-success-500 rounded-full flex items-center justify-center">
                  <div className="w-2 h-2 bg-white rounded-full"></div>
                </div>
              </div>
              
              <h3 className="text-lg font-semibold text-secondary-900 mb-1 group-hover:text-primary-600 transition-colors">
                {student.firstName} {student.lastName}
              </h3>
              
              <p className="text-secondary-600 text-sm mb-4">
                {student.email}
              </p>
              
              <div className="space-y-2 mb-4 text-xs text-secondary-500">
                <div className="flex items-center justify-between">
                  <span>Kurslar:</span>
                  <span className="font-medium">3 ta</span>
                </div>
                <div className="flex items-center justify-between">
                  <span>Tugatgan:</span>
                  <span className="font-medium text-success-600">2 ta</span>
                </div>
                <div className="flex items-center justify-between">
                  <span>Progress:</span>
                  <span className="font-medium">85%</span>
                </div>
              </div>
              
              <div className="w-full bg-secondary-200 rounded-full h-2 mb-4">
                <div 
                  className="bg-primary-600 h-2 rounded-full transition-all duration-300"
                  style={{ width: '85%' }}
                ></div>
              </div>
              
              <Link
                to={`/students/${student.id}`}
                className="btn-outline w-full text-sm"
              >
                Profil ko'rish
              </Link>
            </motion.div>
          ))}
        </div>

        {/* Empty State */}
        {filteredStudents.length === 0 && (
          <div className="text-center py-12">
            <Users className="w-16 h-16 text-secondary-300 mx-auto mb-4" />
            <h3 className="text-xl font-semibold text-secondary-900 mb-2">
              Talabalar topilmadi
            </h3>
            <p className="text-secondary-600 mb-6">
              Qidiruv shartlaringizni o'zgartiring yoki barcha talabalarni ko'ring
            </p>
            <button
              onClick={() => setSearchTerm('')}
              className="btn-primary"
            >
              Qidiruvni tozalash
            </button>
          </div>
        )}
      </div>
    </div>
  )
}