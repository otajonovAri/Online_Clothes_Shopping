import { useState, useEffect } from 'react'
import { useParams, Link } from 'react-router-dom'
import { 
  Star, 
  Clock, 
  Users, 
  BookOpen, 
  Play, 
  CheckCircle, 
  Award,
  ArrowLeft,
  Heart,
  Share2
} from 'lucide-react'
import { motion } from 'framer-motion'
import type { Course } from '../types'

export function CourseDetailPage() {
  const { id } = useParams<{ id: string }>()
  const [course, setCourse] = useState<Course | null>(null)
  const [loading, setLoading] = useState(true)
  const [activeTab, setActiveTab] = useState('overview')

  useEffect(() => {
    // Mock data - replace with API call
    const mockCourse: Course = {
      id: '1',
      title: 'React va TypeScript asoslari',
      description: `Bu kurs React va TypeScript texnologiyalarini chuqur o'rganish uchun mo'ljallangan. 
      Kurs davomida siz zamonaviy web ilovalar yaratish, komponentlar bilan ishlash, state management, 
      va TypeScript bilan type safety ta'minlash usullarini o'rganasiz.
      
      Kurs amaliy loyihalar bilan to'ldirilgan bo'lib, har bir mavzu real misollar orqali tushuntiriladi. 
      Kurs oxirida siz to'liq funksional web ilova yaratishga qodir bo'lasiz.`,
      shortDescription: 'React va TypeScript bilan professional web ilovalar yarating',
      thumbnail: 'https://images.pexels.com/photos/11035380/pexels-photo-11035380.jpeg?auto=compress&cs=tinysrgb&w=800',
      price: 299000,
      duration: 40,
      level: 'beginner',
      category: 'Programming',
      tags: ['React', 'TypeScript', 'JavaScript', 'Web Development'],
      instructorId: '1',
      instructor: {
        id: '1',
        email: 'alisher@example.com',
        firstName: 'Alisher',
        lastName: 'Karimov',
        role: 'instructor',
        avatar: 'https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg?auto=compress&cs=tinysrgb&w=200',
        bio: 'Senior Frontend Developer with 8+ years of experience. Specialized in React, TypeScript, and modern web technologies.',
        expertise: ['React', 'TypeScript', 'JavaScript', 'Node.js'],
        courses: [],
        rating: 4.8,
        totalStudents: 1250,
        createdAt: '2024-01-01',
        updatedAt: '2024-01-01',
      },
      lessons: [
        {
          id: '1',
          title: 'React asoslari va JSX',
          description: 'React kutubxonasi bilan tanishish va JSX sintaksisi',
          videoUrl: '',
          duration: 45,
          order: 1,
          courseId: '1',
        },
        {
          id: '2',
          title: 'Komponentlar va Props',
          description: 'React komponentlari yaratish va props orqali ma\'lumot uzatish',
          videoUrl: '',
          duration: 60,
          order: 2,
          courseId: '1',
        },
        {
          id: '3',
          title: 'State va Event Handling',
          description: 'Komponent holatini boshqarish va hodisalarni qayta ishlash',
          videoUrl: '',
          duration: 55,
          order: 3,
          courseId: '1',
        },
        {
          id: '4',
          title: 'TypeScript bilan ishlash',
          description: 'TypeScript asoslari va React bilan integratsiya',
          videoUrl: '',
          duration: 70,
          order: 4,
          courseId: '1',
        },
      ],
      enrolledStudents: 1250,
      rating: 4.8,
      reviews: [
        {
          id: '1',
          rating: 5,
          comment: 'Juda yaxshi kurs! O\'qituvchi professional va tushuntirish usuli ajoyib.',
          studentId: '1',
          student: {
            id: '1',
            email: 'student@example.com',
            firstName: 'Aziza',
            lastName: 'Normatova',
            role: 'student',
            enrolledCourses: [],
            completedCourses: [],
            progress: [],
            createdAt: '2024-01-01',
            updatedAt: '2024-01-01',
          },
          courseId: '1',
          createdAt: '2024-01-15',
        },
      ],
      createdAt: '2024-01-01',
      updatedAt: '2024-01-01',
    }

    setTimeout(() => {
      setCourse(mockCourse)
      setLoading(false)
    }, 1000)
  }, [id])

  const tabs = [
    { id: 'overview', label: 'Umumiy ma\'lumot' },
    { id: 'curriculum', label: 'Dars rejasi' },
    { id: 'instructor', label: 'O\'qituvchi' },
    { id: 'reviews', label: 'Sharhlar' },
  ]

  if (loading) {
    return (
      <div className="min-h-screen bg-secondary-50 py-12">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="animate-pulse">
            <div className="h-8 bg-secondary-200 rounded w-1/4 mb-8"></div>
            <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
              <div className="lg:col-span-2">
                <div className="h-64 bg-secondary-200 rounded mb-6"></div>
                <div className="h-4 bg-secondary-200 rounded mb-2"></div>
                <div className="h-4 bg-secondary-200 rounded w-3/4"></div>
              </div>
              <div className="bg-white rounded-xl p-6">
                <div className="h-48 bg-secondary-200 rounded"></div>
              </div>
            </div>
          </div>
        </div>
      </div>
    )
  }

  if (!course) {
    return (
      <div className="min-h-screen bg-secondary-50 py-12">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 text-center">
          <h1 className="text-2xl font-bold text-secondary-900 mb-4">
            Kurs topilmadi
          </h1>
          <Link to="/courses" className="btn-primary">
            Kurslar sahifasiga qaytish
          </Link>
        </div>
      </div>
    )
  }

  return (
    <div className="min-h-screen bg-secondary-50 py-12">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        {/* Breadcrumb */}
        <div className="flex items-center space-x-2 text-sm text-secondary-600 mb-8">
          <Link to="/courses" className="hover:text-primary-600 flex items-center">
            <ArrowLeft className="w-4 h-4 mr-1" />
            Kurslar
          </Link>
          <span>/</span>
          <span className="text-secondary-900">{course.title}</span>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
          {/* Main Content */}
          <div className="lg:col-span-2">
            {/* Course Header */}
            <motion.div
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              className="bg-white rounded-xl p-8 mb-8 shadow-sm"
            >
              <div className="flex flex-wrap gap-2 mb-4">
                {course.tags.map(tag => (
                  <span
                    key={tag}
                    className="px-3 py-1 bg-primary-100 text-primary-700 text-sm rounded-full"
                  >
                    {tag}
                  </span>
                ))}
              </div>
              
              <h1 className="text-3xl lg:text-4xl font-bold text-secondary-900 mb-4">
                {course.title}
              </h1>
              
              <p className="text-lg text-secondary-600 mb-6">
                {course.shortDescription}
              </p>
              
              <div className="flex flex-wrap items-center gap-6 text-sm text-secondary-600">
                <div className="flex items-center space-x-1">
                  <Star className="w-4 h-4 text-yellow-400 fill-current" />
                  <span className="font-medium">{course.rating}</span>
                  <span>({course.reviews.length} sharh)</span>
                </div>
                <div className="flex items-center space-x-1">
                  <Users className="w-4 h-4" />
                  <span>{course.enrolledStudents} talaba</span>
                </div>
                <div className="flex items-center space-x-1">
                  <Clock className="w-4 h-4" />
                  <span>{course.duration} soat</span>
                </div>
                <div className="flex items-center space-x-1">
                  <BookOpen className="w-4 h-4" />
                  <span>{course.lessons.length} dars</span>
                </div>
              </div>
            </motion.div>

            {/* Tabs */}
            <div className="bg-white rounded-xl shadow-sm mb-8">
              <div className="border-b border-secondary-200">
                <nav className="flex space-x-8 px-8">
                  {tabs.map(tab => (
                    <button
                      key={tab.id}
                      onClick={() => setActiveTab(tab.id)}
                      className={`py-4 px-1 border-b-2 font-medium text-sm transition-colors ${
                        activeTab === tab.id
                          ? 'border-primary-500 text-primary-600'
                          : 'border-transparent text-secondary-500 hover:text-secondary-700 hover:border-secondary-300'
                      }`}
                    >
                      {tab.label}
                    </button>
                  ))}
                </nav>
              </div>

              <div className="p-8">
                {activeTab === 'overview' && (
                  <div className="space-y-6">
                    <div>
                      <h3 className="text-xl font-semibold text-secondary-900 mb-4">
                        Kurs haqida
                      </h3>
                      <div className="prose prose-secondary max-w-none">
                        {course.description.split('\n').map((paragraph, index) => (
                          <p key={index} className="text-secondary-700 leading-relaxed mb-4">
                            {paragraph}
                          </p>
                        ))}
                      </div>
                    </div>
                    
                    <div>
                      <h3 className="text-xl font-semibold text-secondary-900 mb-4">
                        Nima o'rganasiz
                      </h3>
                      <div className="grid grid-cols-1 md:grid-cols-2 gap-3">
                        {[
                          'React asoslari va JSX sintaksisi',
                          'Komponentlar yaratish va boshqarish',
                          'State va Props bilan ishlash',
                          'TypeScript integratsiyasi',
                          'Event handling va lifecycle',
                          'Amaliy loyiha yaratish',
                        ].map((item, index) => (
                          <div key={index} className="flex items-center space-x-2">
                            <CheckCircle className="w-5 h-5 text-success-500" />
                            <span className="text-secondary-700">{item}</span>
                          </div>
                        ))}
                      </div>
                    </div>
                  </div>
                )}

                {activeTab === 'curriculum' && (
                  <div className="space-y-4">
                    <h3 className="text-xl font-semibold text-secondary-900 mb-6">
                      Dars rejasi ({course.lessons.length} dars)
                    </h3>
                    {course.lessons.map((lesson, index) => (
                      <div
                        key={lesson.id}
                        className="border border-secondary-200 rounded-lg p-4 hover:border-primary-300 transition-colors"
                      >
                        <div className="flex items-center justify-between">
                          <div className="flex items-center space-x-3">
                            <div className="w-8 h-8 bg-primary-100 rounded-full flex items-center justify-center">
                              <Play className="w-4 h-4 text-primary-600" />
                            </div>
                            <div>
                              <h4 className="font-medium text-secondary-900">
                                {lesson.title}
                              </h4>
                              <p className="text-sm text-secondary-600">
                                {lesson.description}
                              </p>
                            </div>
                          </div>
                          <div className="text-sm text-secondary-500">
                            {lesson.duration} daqiqa
                          </div>
                        </div>
                      </div>
                    ))}
                  </div>
                )}

                {activeTab === 'instructor' && (
                  <div className="space-y-6">
                    <div className="flex items-start space-x-4">
                      <img
                        src={course.instructor.avatar}
                        alt={`${course.instructor.firstName} ${course.instructor.lastName}`}
                        className="w-20 h-20 rounded-full object-cover"
                      />
                      <div className="flex-1">
                        <h3 className="text-xl font-semibold text-secondary-900 mb-2">
                          {course.instructor.firstName} {course.instructor.lastName}
                        </h3>
                        <div className="flex items-center space-x-4 text-sm text-secondary-600 mb-4">
                          <div className="flex items-center space-x-1">
                            <Star className="w-4 h-4 text-yellow-400 fill-current" />
                            <span>{course.instructor.rating} reyting</span>
                          </div>
                          <div className="flex items-center space-x-1">
                            <Users className="w-4 h-4" />
                            <span>{course.instructor.totalStudents} talaba</span>
                          </div>
                        </div>
                        <p className="text-secondary-700 leading-relaxed">
                          {course.instructor.bio}
                        </p>
                      </div>
                    </div>
                    
                    <div>
                      <h4 className="font-semibold text-secondary-900 mb-3">
                        Mutaxassislik sohalari
                      </h4>
                      <div className="flex flex-wrap gap-2">
                        {course.instructor.expertise.map(skill => (
                          <span
                            key={skill}
                            className="px-3 py-1 bg-secondary-100 text-secondary-700 text-sm rounded-full"
                          >
                            {skill}
                          </span>
                        ))}
                      </div>
                    </div>
                  </div>
                )}

                {activeTab === 'reviews' && (
                  <div className="space-y-6">
                    <div className="flex items-center justify-between">
                      <h3 className="text-xl font-semibold text-secondary-900">
                        Talabalar sharhlari
                      </h3>
                      <div className="flex items-center space-x-2">
                        <Star className="w-5 h-5 text-yellow-400 fill-current" />
                        <span className="text-lg font-semibold">{course.rating}</span>
                        <span className="text-secondary-600">({course.reviews.length} sharh)</span>
                      </div>
                    </div>
                    
                    <div className="space-y-4">
                      {course.reviews.map(review => (
                        <div key={review.id} className="border-b border-secondary-200 pb-4">
                          <div className="flex items-start space-x-3">
                            <div className="w-10 h-10 bg-primary-100 rounded-full flex items-center justify-center">
                              <span className="text-primary-600 font-medium">
                                {review.student.firstName[0]}
                              </span>
                            </div>
                            <div className="flex-1">
                              <div className="flex items-center space-x-2 mb-2">
                                <span className="font-medium text-secondary-900">
                                  {review.student.firstName} {review.student.lastName}
                                </span>
                                <div className="flex items-center">
                                  {[...Array(review.rating)].map((_, i) => (
                                    <Star key={i} className="w-4 h-4 text-yellow-400 fill-current" />
                                  ))}
                                </div>
                              </div>
                              <p className="text-secondary-700 leading-relaxed">
                                {review.comment}
                              </p>
                            </div>
                          </div>
                        </div>
                      ))}
                    </div>
                  </div>
                )}
              </div>
            </div>
          </div>

          {/* Sidebar */}
          <div className="lg:col-span-1">
            <motion.div
              initial={{ opacity: 0, x: 20 }}
              animate={{ opacity: 1, x: 0 }}
              className="bg-white rounded-xl p-6 shadow-sm sticky top-24"
            >
              <img
                src={course.thumbnail}
                alt={course.title}
                className="w-full h-48 object-cover rounded-lg mb-6"
              />
              
              <div className="text-3xl font-bold text-primary-600 mb-6">
                {course.price.toLocaleString()} so'm
              </div>
              
              <div className="space-y-4 mb-6">
                <button className="w-full btn-primary py-3 text-lg font-semibold">
                  Kursga yozilish
                </button>
                <div className="flex space-x-2">
                  <button className="flex-1 btn-outline flex items-center justify-center">
                    <Heart className="w-4 h-4 mr-2" />
                    Saqlash
                  </button>
                  <button className="flex-1 btn-outline flex items-center justify-center">
                    <Share2 className="w-4 h-4 mr-2" />
                    Ulashish
                  </button>
                </div>
              </div>
              
              <div className="space-y-3 text-sm">
                <div className="flex items-center justify-between">
                  <span className="text-secondary-600">Daraja:</span>
                  <span className="font-medium text-secondary-900">
                    {course.level === 'beginner' ? 'Boshlang\'ich' : 
                     course.level === 'intermediate' ? 'O\'rta' : 'Yuqori'}
                  </span>
                </div>
                <div className="flex items-center justify-between">
                  <span className="text-secondary-600">Davomiyligi:</span>
                  <span className="font-medium text-secondary-900">{course.duration} soat</span>
                </div>
                <div className="flex items-center justify-between">
                  <span className="text-secondary-600">Darslar soni:</span>
                  <span className="font-medium text-secondary-900">{course.lessons.length} ta</span>
                </div>
                <div className="flex items-center justify-between">
                  <span className="text-secondary-600">Sertifikat:</span>
                  <div className="flex items-center space-x-1">
                    <Award className="w-4 h-4 text-success-500" />
                    <span className="font-medium text-secondary-900">Ha</span>
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