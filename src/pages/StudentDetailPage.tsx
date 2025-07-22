import { useState, useEffect } from 'react'
import { useParams, Link } from 'react-router-dom'
import { 
  ArrowLeft,
  BookOpen,
  Award,
  Calendar,
  Mail,
  User,
  TrendingUp,
  Clock,
  CheckCircle
} from 'lucide-react'
import { motion } from 'framer-motion'
import type { Student, Course, CourseProgress } from '../types'

export function StudentDetailPage() {
  const { id } = useParams<{ id: string }>()
  const [student, setStudent] = useState<Student | null>(null)
  const [loading, setLoading] = useState(true)

  useEffect(() => {
    // Mock data - replace with API call
    const mockStudent: Student = {
      id: '1',
      email: 'aziza@example.com',
      firstName: 'Aziza',
      lastName: 'Normatova',
      role: 'student',
      avatar: 'https://images.pexels.com/photos/774909/pexels-photo-774909.jpeg?auto=compress&cs=tinysrgb&w=400',
      enrolledCourses: [
        {
          id: '1',
          title: 'React va TypeScript asoslari',
          description: 'React va TypeScript texnologiyalarini o\'rganing',
          shortDescription: 'React va TypeScript bilan web ilovalar yarating',
          thumbnail: 'https://images.pexels.com/photos/11035380/pexels-photo-11035380.jpeg?auto=compress&cs=tinysrgb&w=300',
          price: 299000,
          duration: 40,
          level: 'beginner',
          category: 'Programming',
          tags: ['React', 'TypeScript'],
          instructorId: '1',
          instructor: {
            id: '1',
            email: 'alisher@example.com',
            firstName: 'Alisher',
            lastName: 'Karimov',
            role: 'instructor',
            bio: 'Senior Frontend Developer',
            expertise: ['React', 'TypeScript'],
            courses: [],
            rating: 4.8,
            totalStudents: 1250,
            createdAt: '2024-01-01',
            updatedAt: '2024-01-01',
          },
          lessons: [],
          enrolledStudents: 1250,
          rating: 4.8,
          reviews: [],
          createdAt: '2024-01-01',
          updatedAt: '2024-01-01',
        },
        {
          id: '2',
          title: 'Python bilan Data Science',
          description: 'Python yordamida data science o\'rganing',
          shortDescription: 'Data Science va Machine Learning asoslari',
          thumbnail: 'https://images.pexels.com/photos/1181671/pexels-photo-1181671.jpeg?auto=compress&cs=tinysrgb&w=300',
          price: 399000,
          duration: 60,
          level: 'intermediate',
          category: 'Data Science',
          tags: ['Python', 'Data Science'],
          instructorId: '2',
          instructor: {
            id: '2',
            email: 'malika@example.com',
            firstName: 'Malika',
            lastName: 'Tosheva',
            role: 'instructor',
            bio: 'Data Scientist',
            expertise: ['Python', 'Data Science'],
            courses: [],
            rating: 4.9,
            totalStudents: 980,
            createdAt: '2024-01-01',
            updatedAt: '2024-01-01',
          },
          lessons: [],
          enrolledStudents: 980,
          rating: 4.9,
          reviews: [],
          createdAt: '2024-01-01',
          updatedAt: '2024-01-01',
        },
      ],
      completedCourses: [
        {
          id: '3',
          title: 'UI/UX Design Masterclass',
          description: 'Professional dizayn ko\'nikmalari',
          shortDescription: 'UI/UX dizayn bo\'yicha to\'liq kurs',
          thumbnail: 'https://images.pexels.com/photos/196644/pexels-photo-196644.jpeg?auto=compress&cs=tinysrgb&w=300',
          price: 349000,
          duration: 35,
          level: 'beginner',
          category: 'Design',
          tags: ['UI/UX', 'Design'],
          instructorId: '3',
          instructor: {
            id: '3',
            email: 'sardor@example.com',
            firstName: 'Sardor',
            lastName: 'Rahimov',
            role: 'instructor',
            bio: 'Senior UI/UX Designer',
            expertise: ['UI/UX', 'Design'],
            courses: [],
            rating: 4.7,
            totalStudents: 750,
            createdAt: '2024-01-01',
            updatedAt: '2024-01-01',
          },
          lessons: [],
          enrolledStudents: 750,
          rating: 4.7,
          reviews: [],
          createdAt: '2024-01-01',
          updatedAt: '2024-01-01',
        },
      ],
      progress: [
        {
          id: '1',
          studentId: '1',
          courseId: '1',
          completedLessons: ['1', '2'],
          progress: 75,
          lastAccessedAt: '2024-01-20',
        },
        {
          id: '2',
          studentId: '1',
          courseId: '2',
          completedLessons: ['1'],
          progress: 25,
          lastAccessedAt: '2024-01-18',
        },
      ],
      createdAt: '2024-01-15',
      updatedAt: '2024-01-20',
    }

    setTimeout(() => {
      setStudent(mockStudent)
      setLoading(false)
    }, 1000)
  }, [id])

  if (loading) {
    return (
      <div className="min-h-screen bg-secondary-50 py-12">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="animate-pulse">
            <div className="h-8 bg-secondary-200 rounded w-1/4 mb-8"></div>
            <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
              <div className="lg:col-span-2">
                <div className="h-64 bg-secondary-200 rounded mb-6"></div>
              </div>
              <div className="bg-white rounded-xl p-6">
                <div className="w-32 h-32 bg-secondary-200 rounded-full mx-auto"></div>
              </div>
            </div>
          </div>
        </div>
      </div>
    )
  }

  if (!student) {
    return (
      <div className="min-h-screen bg-secondary-50 py-12">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 text-center">
          <h1 className="text-2xl font-bold text-secondary-900 mb-4">
            Talaba topilmadi
          </h1>
          <Link to="/students" className="btn-primary">
            Talabalar sahifasiga qaytish
          </Link>
        </div>
      </div>
    )
  }

  const totalCourses = student.enrolledCourses.length + student.completedCourses.length
  const averageProgress = student.progress.reduce((acc, p) => acc + p.progress, 0) / student.progress.length || 0

  return (
    <div className="min-h-screen bg-secondary-50 py-12">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        {/* Breadcrumb */}
        <div className="flex items-center space-x-2 text-sm text-secondary-600 mb-8">
          <Link to="/students" className="hover:text-primary-600 flex items-center">
            <ArrowLeft className="w-4 h-4 mr-1" />
            Talabalar
          </Link>
          <span>/</span>
          <span className="text-secondary-900">
            {student.firstName} {student.lastName}
          </span>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
          {/* Main Content */}
          <div className="lg:col-span-2">
            {/* Student Info */}
            <motion.div
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              className="bg-white rounded-xl p-8 mb-8 shadow-sm"
            >
              <div className="flex items-start space-x-6 mb-6">
                <img
                  src={student.avatar}
                  alt={`${student.firstName} ${student.lastName}`}
                  className="w-24 h-24 rounded-full object-cover"
                />
                <div className="flex-1">
                  <h1 className="text-3xl font-bold text-secondary-900 mb-2">
                    {student.firstName} {student.lastName}
                  </h1>
                  <div className="flex items-center space-x-6 text-secondary-600 mb-4">
                    <div className="flex items-center space-x-1">
                      <BookOpen className="w-5 h-5" />
                      <span>{totalCourses} kurs</span>
                    </div>
                    <div className="flex items-center space-x-1">
                      <Award className="w-5 h-5" />
                      <span>{student.completedCourses.length} tugatgan</span>
                    </div>
                    <div className="flex items-center space-x-1">
                      <TrendingUp className="w-5 h-5" />
                      <span>{Math.round(averageProgress)}% progress</span>
                    </div>
                  </div>
                  <div className="flex items-center space-x-4 text-sm text-secondary-500">
                    <div className="flex items-center space-x-1">
                      <Mail className="w-4 h-4" />
                      <span>{student.email}</span>
                    </div>
                    <div className="flex items-center space-x-1">
                      <Calendar className="w-4 h-4" />
                      <span>2024 yildan beri</span>
                    </div>
                  </div>
                </div>
              </div>
            </motion.div>

            {/* Current Courses */}
            <motion.div
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ delay: 0.1 }}
              className="bg-white rounded-xl p-8 mb-8 shadow-sm"
            >
              <h2 className="text-2xl font-bold text-secondary-900 mb-6">
                Joriy kurslar ({student.enrolledCourses.length})
              </h2>
              <div className="space-y-6">
                {student.enrolledCourses.map((course, index) => {
                  const progress = student.progress.find(p => p.courseId === course.id)
                  return (
                    <div key={course.id} className="border border-secondary-200 rounded-lg p-6">
                      <div className="flex items-start space-x-4">
                        <img
                          src={course.thumbnail}
                          alt={course.title}
                          className="w-20 h-20 object-cover rounded-lg"
                        />
                        <div className="flex-1">
                          <h3 className="text-lg font-semibold text-secondary-900 mb-2">
                            {course.title}
                          </h3>
                          <p className="text-secondary-600 mb-4">
                            O'qituvchi: {course.instructor.firstName} {course.instructor.lastName}
                          </p>
                          
                          <div className="flex items-center space-x-4 mb-4 text-sm text-secondary-500">
                            <div className="flex items-center space-x-1">
                              <Clock className="w-4 h-4" />
                              <span>{course.duration} soat</span>
                            </div>
                            <span className="px-2 py-1 bg-primary-100 text-primary-700 text-xs rounded-full">
                              {course.level === 'beginner' ? 'Boshlang\'ich' : 
                               course.level === 'intermediate' ? 'O\'rta' : 'Yuqori'}
                            </span>
                          </div>
                          
                          {progress && (
                            <div>
                              <div className="flex items-center justify-between mb-2">
                                <span className="text-sm text-secondary-600">Progress</span>
                                <span className="text-sm font-medium text-secondary-900">
                                  {progress.progress}%
                                </span>
                              </div>
                              <div className="w-full bg-secondary-200 rounded-full h-2">
                                <div 
                                  className="bg-primary-600 h-2 rounded-full transition-all duration-300"
                                  style={{ width: `${progress.progress}%` }}
                                ></div>
                              </div>
                            </div>
                          )}
                        </div>
                        <Link
                          to={`/courses/${course.id}`}
                          className="btn-outline text-sm"
                        >
                          Ko'rish
                        </Link>
                      </div>
                    </div>
                  )
                })}
              </div>
            </motion.div>

            {/* Completed Courses */}
            <motion.div
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ delay: 0.2 }}
              className="bg-white rounded-xl p-8 shadow-sm"
            >
              <h2 className="text-2xl font-bold text-secondary-900 mb-6">
                Tugatilgan kurslar ({student.completedCourses.length})
              </h2>
              <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                {student.completedCourses.map(course => (
                  <div key={course.id} className="border border-secondary-200 rounded-lg p-4">
                    <img
                      src={course.thumbnail}
                      alt={course.title}
                      className="w-full h-32 object-cover rounded-lg mb-4"
                    />
                    <h3 className="font-semibold text-secondary-900 mb-2">
                      {course.title}
                    </h3>
                    <p className="text-sm text-secondary-600 mb-4">
                      O'qituvchi: {course.instructor.firstName} {course.instructor.lastName}
                    </p>
                    <div className="flex items-center justify-between">
                      <div className="flex items-center space-x-1 text-success-600">
                        <CheckCircle className="w-4 h-4" />
                        <span className="text-sm font-medium">Tugatilgan</span>
                      </div>
                      <Link
                        to={`/courses/${course.id}`}
                        className="btn-outline text-sm"
                      >
                        Ko'rish
                      </Link>
                    </div>
                  </div>
                ))}
              </div>
            </motion.div>
          </div>

          {/* Sidebar */}
          <div className="lg:col-span-1">
            <motion.div
              initial={{ opacity: 0, x: 20 }}
              animate={{ opacity: 1, x: 0 }}
              className="bg-white rounded-xl p-6 shadow-sm sticky top-24"
            >
              <div className="text-center mb-6">
                <img
                  src={student.avatar}
                  alt={`${student.firstName} ${student.lastName}`}
                  className="w-32 h-32 rounded-full object-cover mx-auto mb-4"
                />
                <h3 className="text-xl font-bold text-secondary-900 mb-2">
                  {student.firstName} {student.lastName}
                </h3>
                <div className="flex items-center justify-center space-x-1 mb-4">
                  <User className="w-5 h-5 text-primary-600" />
                  <span className="text-primary-600 font-medium">Talaba</span>
                </div>
              </div>
              
              <div className="space-y-4 mb-6">
                <div className="flex items-center justify-between">
                  <span className="text-secondary-600">Jami kurslar:</span>
                  <span className="font-medium text-secondary-900">{totalCourses}</span>
                </div>
                <div className="flex items-center justify-between">
                  <span className="text-secondary-600">Tugatgan:</span>
                  <span className="font-medium text-success-600">{student.completedCourses.length}</span>
                </div>
                <div className="flex items-center justify-between">
                  <span className="text-secondary-600">Davom etayotgan:</span>
                  <span className="font-medium text-warning-600">{student.enrolledCourses.length}</span>
                </div>
                <div className="flex items-center justify-between">
                  <span className="text-secondary-600">O'rtacha progress:</span>
                  <span className="font-medium text-secondary-900">{Math.round(averageProgress)}%</span>
                </div>
              </div>
              
              <div className="mb-6">
                <div className="flex items-center justify-between mb-2">
                  <span className="text-sm text-secondary-600">Umumiy progress</span>
                  <span className="text-sm font-medium text-secondary-900">
                    {Math.round(averageProgress)}%
                  </span>
                </div>
                <div className="w-full bg-secondary-200 rounded-full h-3">
                  <div 
                    className="bg-primary-600 h-3 rounded-full transition-all duration-300"
                    style={{ width: `${averageProgress}%` }}
                  ></div>
                </div>
              </div>
              
              <div className="text-center">
                <p className="text-sm text-secondary-600">
                  Ro'yxatdan o'tgan: {new Date(student.createdAt).toLocaleDateString('uz-UZ')}
                </p>
              </div>
            </motion.div>
          </div>
        </div>
      </div>
    </div>
  )
}