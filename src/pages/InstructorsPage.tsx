import { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import { Search, Star, Users, BookOpen, Award } from 'lucide-react'
import { motion } from 'framer-motion'
import type { Instructor } from '../types'

export function InstructorsPage() {
  const [instructors, setInstructors] = useState<Instructor[]>([])
  const [loading, setLoading] = useState(true)
  const [searchTerm, setSearchTerm] = useState('')

  // Mock data - replace with API call
  useEffect(() => {
    const mockInstructors: Instructor[] = [
      {
        id: '1',
        email: 'alisher@example.com',
        firstName: 'Alisher',
        lastName: 'Karimov',
        role: 'instructor',
        avatar: 'https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg?auto=compress&cs=tinysrgb&w=300',
        bio: 'Senior Frontend Developer with 8+ years of experience in React, TypeScript, and modern web technologies. Passionate about teaching and helping students achieve their goals.',
        expertise: ['React', 'TypeScript', 'JavaScript', 'Node.js', 'Next.js'],
        courses: [],
        rating: 4.8,
        totalStudents: 1250,
        createdAt: '2024-01-01',
        updatedAt: '2024-01-01',
      },
      {
        id: '2',
        email: 'malika@example.com',
        firstName: 'Malika',
        lastName: 'Tosheva',
        role: 'instructor',
        avatar: 'https://images.pexels.com/photos/774909/pexels-photo-774909.jpeg?auto=compress&cs=tinysrgb&w=300',
        bio: 'Data Scientist and Machine Learning Engineer with expertise in Python, TensorFlow, and statistical analysis. PhD in Computer Science.',
        expertise: ['Python', 'Data Science', 'Machine Learning', 'TensorFlow', 'Statistics'],
        courses: [],
        rating: 4.9,
        totalStudents: 980,
        createdAt: '2024-01-01',
        updatedAt: '2024-01-01',
      },
      {
        id: '3',
        email: 'sardor@example.com',
        firstName: 'Sardor',
        lastName: 'Rahimov',
        role: 'instructor',
        avatar: 'https://images.pexels.com/photos/1222271/pexels-photo-1222271.jpeg?auto=compress&cs=tinysrgb&w=300',
        bio: 'Senior UI/UX Designer with 6+ years of experience in creating beautiful and functional digital products. Expert in Figma, Adobe Creative Suite.',
        expertise: ['UI/UX Design', 'Figma', 'Adobe XD', 'Photoshop', 'Illustrator'],
        courses: [],
        rating: 4.7,
        totalStudents: 750,
        createdAt: '2024-01-01',
        updatedAt: '2024-01-01',
      },
      {
        id: '4',
        email: 'dilshod@example.com',
        firstName: 'Dilshod',
        lastName: 'Umarov',
        role: 'instructor',
        avatar: 'https://images.pexels.com/photos/1681010/pexels-photo-1681010.jpeg?auto=compress&cs=tinysrgb&w=300',
        bio: 'Full-stack developer and DevOps engineer. Specialized in cloud technologies, Docker, Kubernetes, and CI/CD pipelines.',
        expertise: ['DevOps', 'Docker', 'Kubernetes', 'AWS', 'CI/CD'],
        courses: [],
        rating: 4.6,
        totalStudents: 650,
        createdAt: '2024-01-01',
        updatedAt: '2024-01-01',
      },
    ]

    setTimeout(() => {
      setInstructors(mockInstructors)
      setLoading(false)
    }, 1000)
  }, [])

  const filteredInstructors = instructors.filter(instructor =>
    `${instructor.firstName} ${instructor.lastName}`.toLowerCase().includes(searchTerm.toLowerCase()) ||
    instructor.expertise.some(skill => skill.toLowerCase().includes(searchTerm.toLowerCase()))
  )

  if (loading) {
    return (
      <div className="min-h-screen bg-secondary-50 py-12">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="animate-pulse">
            <div className="h-8 bg-secondary-200 rounded w-1/4 mb-8"></div>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
              {[...Array(6)].map((_, i) => (
                <div key={i} className="bg-white rounded-xl p-6">
                  <div className="w-20 h-20 bg-secondary-200 rounded-full mx-auto mb-4"></div>
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
            Professional o'qituvchilar
          </h1>
          <p className="text-xl text-secondary-600 max-w-2xl mx-auto">
            Tajribali mutaxassislardan o'rganing va professional ko'nikmalaringizni rivojlantiring
          </p>
        </div>

        {/* Search */}
        <div className="max-w-md mx-auto mb-12">
          <div className="relative">
            <Search className="absolute left-3 top-1/2 transform -translate-y-1/2 w-5 h-5 text-secondary-400" />
            <input
              type="text"
              placeholder="O'qituvchi yoki ko'nikma qidirish..."
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
              className="w-full pl-10 pr-4 py-3 border border-secondary-300 rounded-lg focus:ring-2 focus:ring-primary-500 focus:border-transparent text-lg"
            />
          </div>
        </div>

        {/* Results Count */}
        <div className="mb-8">
          <p className="text-secondary-600 text-center">
            {filteredInstructors.length} ta o'qituvchi topildi
          </p>
        </div>

        {/* Instructors Grid */}
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-8">
          {filteredInstructors.map((instructor, index) => (
            <motion.div
              key={instructor.id}
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.6, delay: index * 0.1 }}
              className="card-hover p-6 text-center group"
            >
              <div className="relative mb-6">
                <img
                  src={instructor.avatar}
                  alt={`${instructor.firstName} ${instructor.lastName}`}
                  className="w-20 h-20 rounded-full object-cover mx-auto group-hover:scale-105 transition-transform duration-300"
                />
                <div className="absolute -bottom-2 -right-2 w-8 h-8 bg-primary-600 rounded-full flex items-center justify-center">
                  <Award className="w-4 h-4 text-white" />
                </div>
              </div>
              
              <h3 className="text-xl font-semibold text-secondary-900 mb-2 group-hover:text-primary-600 transition-colors">
                {instructor.firstName} {instructor.lastName}
              </h3>
              
              <p className="text-secondary-600 mb-4 line-clamp-3 text-sm leading-relaxed">
                {instructor.bio}
              </p>
              
              <div className="flex items-center justify-center space-x-4 mb-4 text-sm text-secondary-500">
                <div className="flex items-center space-x-1">
                  <Star className="w-4 h-4 text-yellow-400 fill-current" />
                  <span className="font-medium">{instructor.rating}</span>
                </div>
                <div className="flex items-center space-x-1">
                  <Users className="w-4 h-4" />
                  <span>{instructor.totalStudents}</span>
                </div>
              </div>
              
              <div className="mb-6">
                <div className="flex flex-wrap gap-1 justify-center">
                  {instructor.expertise.slice(0, 3).map(skill => (
                    <span
                      key={skill}
                      className="px-2 py-1 bg-primary-100 text-primary-700 text-xs rounded-full"
                    >
                      {skill}
                    </span>
                  ))}
                  {instructor.expertise.length > 3 && (
                    <span className="px-2 py-1 bg-secondary-100 text-secondary-600 text-xs rounded-full">
                      +{instructor.expertise.length - 3}
                    </span>
                  )}
                </div>
              </div>
              
              <Link
                to={`/instructors/${instructor.id}`}
                className="btn-primary w-full text-sm"
              >
                Profil ko'rish
              </Link>
            </motion.div>
          ))}
        </div>

        {/* Empty State */}
        {filteredInstructors.length === 0 && (
          <div className="text-center py-12">
            <Users className="w-16 h-16 text-secondary-300 mx-auto mb-4" />
            <h3 className="text-xl font-semibold text-secondary-900 mb-2">
              O'qituvchilar topilmadi
            </h3>
            <p className="text-secondary-600 mb-6">
              Qidiruv shartlaringizni o'zgartiring yoki barcha o'qituvchilarni ko'ring
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