import { useState } from 'react'
import { useForm } from 'react-hook-form'
import { zodResolver } from '@hookform/resolvers/zod'
import { z } from 'zod'
import { 
  User, 
  Mail, 
  Calendar, 
  MapPin, 
  Phone, 
  Edit3, 
  Save, 
  X,
  Camera,
  Award,
  BookOpen,
  TrendingUp
} from 'lucide-react'
import { motion } from 'framer-motion'
import { useAuth } from '../hooks/useAuth'
import toast from 'react-hot-toast'

const profileSchema = z.object({
  firstName: z.string().min(2, 'Ism kamida 2 ta belgidan iborat bo\'lishi kerak'),
  lastName: z.string().min(2, 'Familiya kamida 2 ta belgidan iborat bo\'lishi kerak'),
  email: z.string().email('Noto\'g\'ri email format'),
  phone: z.string().optional(),
  location: z.string().optional(),
  bio: z.string().optional(),
})

type ProfileFormData = z.infer<typeof profileSchema>

export function ProfilePage() {
  const { user } = useAuth()
  const [isEditing, setIsEditing] = useState(false)
  const [activeTab, setActiveTab] = useState('profile')

  const {
    register,
    handleSubmit,
    formState: { errors, isSubmitting },
    reset,
  } = useForm<ProfileFormData>({
    resolver: zodResolver(profileSchema),
    defaultValues: {
      firstName: user?.firstName || '',
      lastName: user?.lastName || '',
      email: user?.email || '',
      phone: '',
      location: 'Toshkent, O\'zbekiston',
      bio: user?.role === 'instructor' ? 'Professional o\'qituvchi va dasturchi' : 'EduFinder platformasida o\'qiyotgan talaba',
    },
  })

  const onSubmit = async (data: ProfileFormData) => {
    try {
      // API call to update profile
      console.log('Updating profile:', data)
      toast.success('Profil muvaffaqiyatli yangilandi!')
      setIsEditing(false)
    } catch (error) {
      toast.error('Profil yangilanishida xatolik yuz berdi')
    }
  }

  const handleCancel = () => {
    reset()
    setIsEditing(false)
  }

  const tabs = [
    { id: 'profile', label: 'Profil ma\'lumotlari' },
    { id: 'courses', label: 'Mening kurslarim' },
    { id: 'achievements', label: 'Yutuqlar' },
    { id: 'settings', label: 'Sozlamalar' },
  ]

  const stats = [
    {
      label: 'Kurslar',
      value: user?.role === 'instructor' ? '5' : '3',
      icon: BookOpen,
      color: 'primary',
    },
    {
      label: user?.role === 'instructor' ? 'Talabalar' : 'Tugatgan',
      value: user?.role === 'instructor' ? '1,250' : '2',
      icon: user?.role === 'instructor' ? User : Award,
      color: 'success',
    },
    {
      label: user?.role === 'instructor' ? 'Reyting' : 'Progress',
      value: user?.role === 'instructor' ? '4.8' : '85%',
      icon: TrendingUp,
      color: 'warning',
    },
  ]

  return (
    <div className="min-h-screen bg-secondary-50 py-12">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
          {/* Profile Sidebar */}
          <div className="lg:col-span-1">
            <motion.div
              initial={{ opacity: 0, x: -20 }}
              animate={{ opacity: 1, x: 0 }}
              className="bg-white rounded-xl p-6 shadow-sm sticky top-24"
            >
              {/* Avatar */}
              <div className="text-center mb-6">
                <div className="relative inline-block">
                  <div className="w-32 h-32 bg-primary-100 rounded-full flex items-center justify-center mx-auto mb-4">
                    {user?.avatar ? (
                      <img
                        src={user.avatar}
                        alt={`${user.firstName} ${user.lastName}`}
                        className="w-32 h-32 rounded-full object-cover"
                      />
                    ) : (
                      <User className="w-16 h-16 text-primary-600" />
                    )}
                  </div>
                  <button className="absolute bottom-4 right-0 w-8 h-8 bg-primary-600 rounded-full flex items-center justify-center text-white hover:bg-primary-700 transition-colors">
                    <Camera className="w-4 h-4" />
                  </button>
                </div>
                <h2 className="text-xl font-bold text-secondary-900 mb-1">
                  {user?.firstName} {user?.lastName}
                </h2>
                <p className="text-secondary-600 capitalize">
                  {user?.role === 'instructor' ? 'O\'qituvchi' : 'Talaba'}
                </p>
              </div>

              {/* Stats */}
              <div className="grid grid-cols-1 gap-4 mb-6">
                {stats.map((stat) => (
                  <div key={stat.label} className="text-center p-3 bg-secondary-50 rounded-lg">
                    <div className={`w-8 h-8 bg-${stat.color}-100 rounded-lg flex items-center justify-center mx-auto mb-2`}>
                      <stat.icon className={`w-4 h-4 text-${stat.color}-600`} />
                    </div>
                    <div className="text-lg font-bold text-secondary-900">
                      {stat.value}
                    </div>
                    <div className="text-xs text-secondary-600">
                      {stat.label}
                    </div>
                  </div>
                ))}
              </div>

              {/* Contact Info */}
              <div className="space-y-3 text-sm">
                <div className="flex items-center space-x-2 text-secondary-600">
                  <Mail className="w-4 h-4" />
                  <span>{user?.email}</span>
                </div>
                <div className="flex items-center space-x-2 text-secondary-600">
                  <Calendar className="w-4 h-4" />
                  <span>2024 yildan beri</span>
                </div>
                <div className="flex items-center space-x-2 text-secondary-600">
                  <MapPin className="w-4 h-4" />
                  <span>Toshkent, O'zbekiston</span>
                </div>
              </div>
            </motion.div>
          </div>

          {/* Main Content */}
          <div className="lg:col-span-2">
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
                {activeTab === 'profile' && (
                  <motion.div
                    initial={{ opacity: 0, y: 20 }}
                    animate={{ opacity: 1, y: 0 }}
                    className="space-y-6"
                  >
                    <div className="flex items-center justify-between">
                      <h3 className="text-xl font-semibold text-secondary-900">
                        Shaxsiy ma'lumotlar
                      </h3>
                      {!isEditing ? (
                        <button
                          onClick={() => setIsEditing(true)}
                          className="btn-outline flex items-center space-x-2"
                        >
                          <Edit3 className="w-4 h-4" />
                          <span>Tahrirlash</span>
                        </button>
                      ) : (
                        <div className="flex space-x-2">
                          <button
                            onClick={handleCancel}
                            className="btn-ghost flex items-center space-x-2"
                          >
                            <X className="w-4 h-4" />
                            <span>Bekor qilish</span>
                          </button>
                          <button
                            onClick={handleSubmit(onSubmit)}
                            disabled={isSubmitting}
                            className="btn-primary flex items-center space-x-2"
                          >
                            <Save className="w-4 h-4" />
                            <span>Saqlash</span>
                          </button>
                        </div>
                      )}
                    </div>

                    <form onSubmit={handleSubmit(onSubmit)} className="space-y-6">
                      <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                        <div>
                          <label className="block text-sm font-medium text-secondary-700 mb-2">
                            Ism
                          </label>
                          <input
                            {...register('firstName')}
                            type="text"
                            disabled={!isEditing}
                            className={`input ${!isEditing ? 'bg-secondary-50' : ''} ${errors.firstName ? 'border-error-500' : ''}`}
                          />
                          {errors.firstName && (
                            <p className="mt-1 text-sm text-error-600">{errors.firstName.message}</p>
                          )}
                        </div>
                        <div>
                          <label className="block text-sm font-medium text-secondary-700 mb-2">
                            Familiya
                          </label>
                          <input
                            {...register('lastName')}
                            type="text"
                            disabled={!isEditing}
                            className={`input ${!isEditing ? 'bg-secondary-50' : ''} ${errors.lastName ? 'border-error-500' : ''}`}
                          />
                          {errors.lastName && (
                            <p className="mt-1 text-sm text-error-600">{errors.lastName.message}</p>
                          )}
                        </div>
                      </div>

                      <div>
                        <label className="block text-sm font-medium text-secondary-700 mb-2">
                          Email
                        </label>
                        <input
                          {...register('email')}
                          type="email"
                          disabled={!isEditing}
                          className={`input ${!isEditing ? 'bg-secondary-50' : ''} ${errors.email ? 'border-error-500' : ''}`}
                        />
                        {errors.email && (
                          <p className="mt-1 text-sm text-error-600">{errors.email.message}</p>
                        )}
                      </div>

                      <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                        <div>
                          <label className="block text-sm font-medium text-secondary-700 mb-2">
                            Telefon
                          </label>
                          <input
                            {...register('phone')}
                            type="tel"
                            disabled={!isEditing}
                            className={`input ${!isEditing ? 'bg-secondary-50' : ''}`}
                            placeholder="+998 90 123 45 67"
                          />
                        </div>
                        <div>
                          <label className="block text-sm font-medium text-secondary-700 mb-2">
                            Joylashuv
                          </label>
                          <input
                            {...register('location')}
                            type="text"
                            disabled={!isEditing}
                            className={`input ${!isEditing ? 'bg-secondary-50' : ''}`}
                          />
                        </div>
                      </div>

                      <div>
                        <label className="block text-sm font-medium text-secondary-700 mb-2">
                          Bio
                        </label>
                        <textarea
                          {...register('bio')}
                          rows={4}
                          disabled={!isEditing}
                          className={`input ${!isEditing ? 'bg-secondary-50' : ''}`}
                          placeholder="O'zingiz haqingizda qisqacha ma'lumot..."
                        />
                      </div>
                    </form>
                  </motion.div>
                )}

                {activeTab === 'courses' && (
                  <motion.div
                    initial={{ opacity: 0, y: 20 }}
                    animate={{ opacity: 1, y: 0 }}
                    className="space-y-6"
                  >
                    <h3 className="text-xl font-semibold text-secondary-900">
                      {user?.role === 'instructor' ? 'Mening kurslarim' : 'Yozilgan kurslar'}
                    </h3>
                    <div className="text-center py-12">
                      <BookOpen className="w-16 h-16 text-secondary-300 mx-auto mb-4" />
                      <p className="text-secondary-600">
                        {user?.role === 'instructor' 
                          ? 'Hali kurslar yaratilmagan' 
                          : 'Hali kurslarga yozilmagansiz'
                        }
                      </p>
                    </div>
                  </motion.div>
                )}

                {activeTab === 'achievements' && (
                  <motion.div
                    initial={{ opacity: 0, y: 20 }}
                    animate={{ opacity: 1, y: 0 }}
                    className="space-y-6"
                  >
                    <h3 className="text-xl font-semibold text-secondary-900">
                      Yutuqlar va sertifikatlar
                    </h3>
                    <div className="text-center py-12">
                      <Award className="w-16 h-16 text-secondary-300 mx-auto mb-4" />
                      <p className="text-secondary-600">
                        Hali yutuqlar yo'q
                      </p>
                    </div>
                  </motion.div>
                )}

                {activeTab === 'settings' && (
                  <motion.div
                    initial={{ opacity: 0, y: 20 }}
                    animate={{ opacity: 1, y: 0 }}
                    className="space-y-6"
                  >
                    <h3 className="text-xl font-semibold text-secondary-900">
                      Hisob sozlamalari
                    </h3>
                    <div className="space-y-4">
                      <div className="flex items-center justify-between p-4 border border-secondary-200 rounded-lg">
                        <div>
                          <h4 className="font-medium text-secondary-900">Email bildirishnomalar</h4>
                          <p className="text-sm text-secondary-600">Yangi kurslar va yangiliklar haqida xabar olish</p>
                        </div>
                        <input type="checkbox" className="toggle" defaultChecked />
                      </div>
                      <div className="flex items-center justify-between p-4 border border-secondary-200 rounded-lg">
                        <div>
                          <h4 className="font-medium text-secondary-900">SMS bildirishnomalar</h4>
                          <p className="text-sm text-secondary-600">Muhim yangiliklar uchun SMS olish</p>
                        </div>
                        <input type="checkbox" className="toggle" />
                      </div>
                    </div>
                  </motion.div>
                )}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}