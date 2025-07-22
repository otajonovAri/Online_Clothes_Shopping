import { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import { 
  BookOpen, 
  Users, 
  Award, 
  TrendingUp, 
  Clock, 
  Play,
  CheckCircle,
  Star
} from 'lucide-react'
import { motion } from 'framer-motion'
import { useAuth } from '../hooks/useAuth'
import type { Course, CourseProgress } from '../types'

export function DashboardPage() {
  const { user } = useAuth()
  const [courses, setCourses] = useState<Course[]>([])
  const [progress, setProgress] = useState<CourseProgress[]>([])
  const [loading, setLoading] = useState(true)

  useEffect(() => {
    // Mock data - replace with API calls
    const mockCourses: Course[] = [
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
    ]

    const mockProgress: CourseProgress[] = [
      {
        id: '1',
        studentId: user?.id || '1',
        courseId: '1',
        completedLessons: ['1', '2'],
        progress: 75,
        lastAccessedAt: '2024-01-20',
      },
      {
        id: '2',
        studentId: user?.id || '1',
        courseId: '2',
        completedLessons: ['1'],
        progress: 25,
        lastAccessedAt: '2024-01-18',
      },
    ]

    setTimeout(() => {
      setCourses(mockCourses)
      setProgress(mockProgress)
      setLoading(false)
    }, 1000)
  }, [user])

  const stats = [
    {
      label: 'Joriy kurslar',
      value: courses.length,
      icon: BookOpen,
      color: 'primary',
    },
    {
      label: 'Tugatilgan darslar',
      value: progress.reduce((acc, p) => acc + p.completedLessons.length, 0),
      icon: CheckCircle,
      color: 'success',
    },
    {
      label: 'O\'rtacha progress',
      value: `${Math.round(progress.reduce((acc, p) => acc + p.progress, 0) / progress.length || 0)}%`,
      icon: TrendingUp,
      color: 'warning',
    },
    {
      label: 'Sertifikatlar',
      value: 2,
      icon: Award,
      color: 'error',
    },
  ]

  if (loading) {
    return (
      <div className="min-h-screen bg-secondary-50 py-12">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="animate-pulse">
            <div className="h-8 bg-secondary-200 rounded w-1/4 mb-8"></div>
            <div className="grid grid-cols-1 md:grid-cols-4 gap-6 mb-8">
              {[...Array(4)].map((_, i) => (
                <div key={i} className="bg-white rounded-xl p-6">
                  <div className="h-12 bg-secondary-200 rounded mb-4"></div>
                  <div className="h-4 bg-secondary-200 rounded"></div>
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
        <div className="mb-8">
          <h1 className="text-3xl lg:text-4xl font-bold text-secondary-900 mb-2">
            Xush kelibsiz, {user?.firstName}!
          </h1>
          <p className="text-xl text-secondary-600">
            O'qish jarayoningizni kuzatib boring va muvaffaqiyatga erishing
          </p>
        </div>

        {/* Stats */}
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6 mb-8">
          {stats.map((stat, index) => (
            <motion.div
              key={stat.label}
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.6, delay: index * 0.1 }}
              className="bg-white rounded-xl p-6 shadow-sm"
            >
              <div className="flex items-center justify-between mb-4">
                <div className={`w-12 h-12 bg-${stat.color}-100 rounded-lg flex items-center justify-center`}>
                  <stat.icon className={`w-6 h-6 text-${stat.color}-600`} />
                </div>
              </div>
              <div className="text-2xl font-bold text-secondary-900 mb-1">
                {stat.value}
              </div>
              <div className="text-secondary-600 text-sm">
                {stat.label}
              </div>
            </motion.div>
          ))}
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
          {/* Current Courses */}
          <div className="lg:col-span-2">
            <motion.div
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ delay: 0.2 }}
              className="bg-white rounded-xl p-8 shadow-sm"
            >
              <div className="flex items-center justify-between mb-6">
                <h2 className="text-2xl font-bold text-secondary-900">
                  Joriy kurslar
                </h2>
                <Link to="/courses" className="text-primary-600 hover:text-primary-700 text-sm font-medium">
                  Barchasini ko'rish
                </Link>
              </div>

              <div className="space-y-6">
                {courses.map((course) => {
                  const courseProgress = progress.find(p => p.courseId === course.id)
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
                            <div className="flex items-center space-x-1">
                              <Star className="w-4 h-4 text-yellow-400 fill-current" />
                              <span>{course.rating}</span>
                            </div>
                          </div>
                          
                          {courseProgress && (
                            <div className="mb-4">
                              <div className="flex items-center justify-between mb-2">
                                <span className="text-sm text-secondary-600">Progress</span>
                                <span className="text-sm font-medium text-secondary-900">
                                  {courseProgress.progress}%
                                </span>
                              </div>
                              <div className="w-full bg-secondary-200 rounded-full h-2">
                                <div 
                                  className="bg-primary-600 h-2 rounded-full transition-all duration-300"
                                  style={{ width: `${courseProgress.progress}%` }}
                                ></div>
                              </div>
                            </div>
                          )}
                          
                          <div className="flex items-center space-x-3">
                            <Link
                              to={`/courses/${course.id}`}
                              className="btn-primary text-sm flex items-center space-x-1"
                            >
                              <Play className="w-4 h-4" />
                              <span>Davom etish</span>
                            </Link>
                            <span className="px-2 py-1 bg-primary-100 text-primary-700 text-xs rounded-full">
                              {course.level === 'beginner' ? 'Boshlang\'ich' : 
                               course.level === 'intermediate' ? 'O\'rta' : 'Yuqori'}
                            </span>
                          </div>
                        </div>
                      </div>
                    </div>
                  )
                })}
              </div>
            </motion.div>
          </div>

          {/* Sidebar */}
          <div className="lg:col-span-1">
            {/* Recent Activity */}
            <motion.div
              initial={{ opacity: 0, x: 20 }}
              animate={{ opacity: 1, x: 0 }}
              transition={{ delay: 0.3 }}
              className="bg-white rounded-xl p-6 shadow-sm mb-8"
            >
              <h3 className="text-lg font-semibold text-secondary-900 mb-4">
                So'nggi faollik
              </h3>
              <div className="space-y-4">
                <div className="flex items-center space-x-3">
                  <div className="w-8 h-8 bg-success-100 rounded-full flex items-center justify-center">
                    <CheckCircle className="w-4 h-4 text-success-600" />
                  </div>
                  <div className="flex-1">
                    <p className="text-sm text-secondary-900">
                      "React Components" darsini tugatdingiz
                    </p>
                    <p className="text-xs text-secondary-500">2 soat oldin</p>
                  </div>
                </div>
                <div className="flex items-center space-x-3">
                  <div className="w-8 h-8 bg-primary-100 rounded-full flex items-center justify-center">
                    <BookOpen className="w-4 h-4 text-primary-600" />
                  </div>
                  <div className="flex-1">
                    <p className="text-sm text-secondary-900">
                      Yangi kursga yozildingiz
                    </p>
                    <p className="text-xs text-secondary-500">1 kun oldin</p>
                  </div>
                </div>
                <div className="flex items-center space-x-3">
                  <div className="w-8 h-8 bg-warning-100 rounded-full flex items-center justify-center">
                    <Award className="w-4 h-4 text-warning-600" />
                  </div>
                  <div className="flex-1">
                    <p className="text-sm text-secondary-900">
                      Sertifikat olindingiz
                    </p>
                    <p className="text-xs text-secondary-500">3 kun oldin</p>
                  </div>
                </div>
              </div>
            </motion.div>

            {/* Recommendations */}
            <motion.div
              initial={{ opacity: 0, x: 20 }}
              animate={{ opacity: 1, x: 0 }}
              transition={{ delay: 0.4 }}
              className="bg-white rounded-xl p-6 shadow-sm"
            >
              <h3 className="text-lg font-semibold text-secondary-900 mb-4">
                Tavsiya etilgan kurslar
              </h3>
              <div className="space-y-4">
                <div className="border border-secondary-200 rounded-lg p-4">
                  <img
                    src="https://images.pexels.com/photos/196644/pexels-photo-196644.jpeg?auto=compress&cs=tinysrgb&w=200"
                    alt="UI/UX Design"
                    className="w-full h-24 object-cover rounded-lg mb-3"
                  />
                  <h4 className="font-medium text-secondary-900 mb-2">
                    UI/UX Design Masterclass
                  </h4>
                  <div className="flex items-center justify-between">
                    <span className="text-sm text-primary-600 font-medium">
                      349,000 so'm
                    </span>
                    <Link to="/courses/3" className="btn-primary text-xs">
                      Ko'rish
                    </Link>
                  </div>
                </div>
              </div>
            </motion.div>
          </div>
        </div>
      </div>
    </div>
  )
}