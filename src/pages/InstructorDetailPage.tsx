import { useState, useEffect } from 'react'
import { useParams, Link } from 'react-router-dom'
import { 
  Star, 
  Users, 
  BookOpen, 
  Award,
  ArrowLeft,
  Mail,
  Calendar,
  MapPin
} from 'lucide-react'
import { motion } from 'framer-motion'
import type { Instructor, Course } from '../types'

export function InstructorDetailPage() {
  const { id } = useParams<{ id: string }>()
  const [instructor, setInstructor] = useState<Instructor | null>(null)
  const [courses, setCourses] = useState<Course[]>([])
  const [loading, setLoading] = useState(true)

  useEffect(() => {
    // Mock data - replace with API call
    const mockInstructor: Instructor = {
      id: '1',
      email: 'alisher@example.com',
      firstName: 'Alisher',
      lastName: 'Karimov',
      role: 'instructor',
      avatar: 'https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg?auto=compress&cs=tinysrgb&w=400',
      bio: `Senior Frontend Developer with 8+ years of experience in React, TypeScript, and modern web technologies. 
      
      I'm passionate about teaching and helping students achieve their goals. Throughout my career, I've worked with various companies from startups to large enterprises, building scalable web applications and leading development teams.
      
      My teaching approach focuses on practical, hands-on learning with real-world projects that prepare students for their professional careers.`,
      expertise: ['React', 'TypeScript', 'JavaScript', 'Node.js', 'Next.js', 'GraphQL', 'MongoDB'],
      courses: [],
      rating: 4.8,
      totalStudents: 1250,
      createdAt: '2024-01-01',
      updatedAt: '2024-01-01',
    }

    const mockCourses: Course[] = [
      {
        id: '1',
        title: 'React va TypeScript asoslari',
        description: 'React va TypeScript texnologiyalarini chuqur o\'rganish',
        shortDescription: 'React va TypeScript bilan professional web ilovalar yarating',
        thumbnail: 'https://images.pexels.com/photos/11035380/pexels-photo-11035380.jpeg?auto=compress&cs=tinysrgb&w=500',
        price: 299000,
        duration: 40,
        level: 'beginner',
        category: 'Programming',
        tags: ['React', 'TypeScript'],
        instructorId: '1',
        instructor: mockInstructor,
        lessons: [],
        enrolledStudents: 850,
        rating: 4.8,
        reviews: [],
        createdAt: '2024-01-01',
        updatedAt: '2024-01-01',
      },
      {
        id: '2',
        title: 'Advanced React Patterns',
        description: 'Ilg\'or React naqshlar va arxitektura',
        shortDescription: 'React da professional naqshlar va best practices',
        thumbnail: 'https://images.pexels.com/photos/1181671/pexels-photo-1181671.jpeg?auto=compress&cs=tinysrgb&w=500',
        price: 399000,
        duration: 50,
        level: 'advanced',
        category: 'Programming',
        tags: ['React', 'Advanced'],
        instructorId: '1',
        instructor: mockInstructor,
        lessons: [],
        enrolledStudents: 400,
        rating: 4.9,
        reviews: [],
        createdAt: '2024-01-01',
        updatedAt: '2024-01-01',
      },
    ]

    setTimeout(() => {
      setInstructor(mockInstructor)
      setCourses(mockCourses)
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

  if (!instructor) {
    return (
      <div className="min-h-screen bg-secondary-50 py-12">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 text-center">
          <h1 className="text-2xl font-bold text-secondary-900 mb-4">
            O'qituvchi topilmadi
          </h1>
          <Link to="/instructors" className="btn-primary">
            O'qituvchilar sahifasiga qaytish
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
          <Link to="/instructors" className="hover:text-primary-600 flex items-center">
            <ArrowLeft className="w-4 h-4 mr-1" />
            O'qituvchilar
          </Link>
          <span>/</span>
          <span className="text-secondary-900">
            {instructor.firstName} {instructor.lastName}
          </span>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
          {/* Main Content */}
          <div className="lg:col-span-2">
            {/* Instructor Info */}
            <motion.div
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              className="bg-white rounded-xl p-8 mb-8 shadow-sm"
            >
              <div className="flex items-start space-x-6 mb-6">
                <img
                  src={instructor.avatar}
                  alt={`${instructor.firstName} ${instructor.lastName}`}
                  className="w-24 h-24 rounded-full object-cover"
                />
                <div className="flex-1">
                  <h1 className="text-3xl font-bold text-secondary-900 mb-2">
                    {instructor.firstName} {instructor.lastName}
                  </h1>
                  <div className="flex items-center space-x-6 text-secondary-600 mb-4">
                    <div className="flex items-center space-x-1">
                      <Star className="w-5 h-5 text-yellow-400 fill-current" />
                      <span className="font-medium">{instructor.rating}</span>
                      <span>reyting</span>
                    </div>
                    <div className="flex items-center space-x-1">
                      <Users className="w-5 h-5" />
                      <span>{instructor.totalStudents} talaba</span>
                    </div>
                    <div className="flex items-center space-x-1">
                      <BookOpen className="w-5 h-5" />
                      <span>{courses.length} kurs</span>
                    </div>
                  </div>
                  <div className="flex items-center space-x-4 text-sm text-secondary-500">
                    <div className="flex items-center space-x-1">
                      <Mail className="w-4 h-4" />
                      <span>{instructor.email}</span>
                    </div>
                    <div className="flex items-center space-x-1">
                      <Calendar className="w-4 h-4" />
                      <span>2024 yildan beri</span>
                    </div>
                  </div>
                </div>
              </div>
              
              <div className="prose prose-secondary max-w-none">
                {instructor.bio.split('\n').map((paragraph, index) => (
                  <p key={index} className="text-secondary-700 leading-relaxed mb-4">
                    {paragraph}
                  </p>
                ))}
              </div>
            </motion.div>

            {/* Expertise */}
            <motion.div
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ delay: 0.1 }}
              className="bg-white rounded-xl p-8 mb-8 shadow-sm"
            >
              <h2 className="text-2xl font-bold text-secondary-900 mb-6">
                Mutaxassislik sohalari
              </h2>
              <div className="flex flex-wrap gap-3">
                {instructor.expertise.map(skill => (
                  <span
                    key={skill}
                    className="px-4 py-2 bg-primary-100 text-primary-700 font-medium rounded-lg"
                  >
                    {skill}
                  </span>
                ))}
              </div>
            </motion.div>

            {/* Courses */}
            <motion.div
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ delay: 0.2 }}
              className="bg-white rounded-xl p-8 shadow-sm"
            >
              <h2 className="text-2xl font-bold text-secondary-900 mb-6">
                Kurslar ({courses.length})
              </h2>
              <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                {courses.map(course => (
                  <div key={course.id} className="border border-secondary-200 rounded-lg p-4 hover:border-primary-300 transition-colors">
                    <img
                      src={course.thumbnail}
                      alt={course.title}
                      className="w-full h-32 object-cover rounded-lg mb-4"
                    />
                    <h3 className="font-semibold text-secondary-900 mb-2">
                      {course.title}
                    </h3>
                    <p className="text-sm text-secondary-600 mb-4 line-clamp-2">
                      {course.shortDescription}
                    </p>
                    <div className="flex items-center justify-between mb-4">
                      <div className="flex items-center space-x-4 text-sm text-secondary-500">
                        <div className="flex items-center space-x-1">
                          <Star className="w-4 h-4 text-yellow-400 fill-current" />
                          <span>{course.rating}</span>
                        </div>
                        <div className="flex items-center space-x-1">
                          <Users className="w-4 h-4" />
                          <span>{course.enrolledStudents}</span>
                        </div>
                      </div>
                      <span className="px-2 py-1 bg-primary-100 text-primary-700 text-xs rounded-full">
                        {course.level === 'beginner' ? 'Boshlang\'ich' : 
                         course.level === 'intermediate' ? 'O\'rta' : 'Yuqori'}
                      </span>
                    </div>
                    <div className="flex items-center justify-between">
                      <div className="text-lg font-bold text-primary-600">
                        {course.price.toLocaleString()} so'm
                      </div>
                      <Link
                        to={`/courses/${course.id}`}
                        className="btn-primary text-sm"
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
                  src={instructor.avatar}
                  alt={`${instructor.firstName} ${instructor.lastName}`}
                  className="w-32 h-32 rounded-full object-cover mx-auto mb-4"
                />
                <h3 className="text-xl font-bold text-secondary-900 mb-2">
                  {instructor.firstName} {instructor.lastName}
                </h3>
                <div className="flex items-center justify-center space-x-1 mb-4">
                  <Award className="w-5 h-5 text-primary-600" />
                  <span className="text-primary-600 font-medium">Professional o'qituvchi</span>
                </div>
              </div>
              
              <div className="space-y-4 mb-6">
                <div className="flex items-center justify-between">
                  <span className="text-secondary-600">Reyting:</span>
                  <div className="flex items-center space-x-1">
                    <Star className="w-4 h-4 text-yellow-400 fill-current" />
                    <span className="font-medium text-secondary-900">{instructor.rating}</span>
                  </div>
                </div>
                <div className="flex items-center justify-between">
                  <span className="text-secondary-600">Talabalar:</span>
                  <span className="font-medium text-secondary-900">{instructor.totalStudents}</span>
                </div>
                <div className="flex items-center justify-between">
                  <span className="text-secondary-600">Kurslar:</span>
                  <span className="font-medium text-secondary-900">{courses.length}</span>
                </div>
                <div className="flex items-center justify-between">
                  <span className="text-secondary-600">Tajriba:</span>
                  <span className="font-medium text-secondary-900">8+ yil</span>
                </div>
              </div>
              
              <button className="w-full btn-primary mb-4">
                Bog'lanish
              </button>
              
              <div className="text-center">
                <p className="text-sm text-secondary-600">
                  Savollaringiz bormi? O'qituvchi bilan bog'laning
                </p>
              </div>
            </motion.div>
          </div>
        </div>
      </div>
    </div>
  )
}